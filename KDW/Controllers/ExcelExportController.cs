
using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;

using KDW.Models;

using System.Data;
using System.Data.Entity;
using System.IO;
using System.Drawing;
using System.Diagnostics;
using System.Web.UI;
using Opredelenie;



namespace KDW.Controllers
{
    public class ExcelExport
    {
        public int ver = 0;



      



        public static void StandartExport(List<string> Stolbci, List<List<string>> Stroki, List<string> Shapka, string path)
        {


            Excel.Application ApExcel = new Excel.Application();
            Excel.Workbooks WB = null;
            WB = ApExcel.Workbooks;
            Excel.Workbook WbExcel = ApExcel.Workbooks.Add(System.Reflection.Missing.Value);
            Excel.Worksheet WS = WbExcel.Sheets[1];
            Excel.Range range;//рэндж
            ApExcel.Visible = false;//невидимо
            ApExcel.ScreenUpdating = false;//и не обновляемо
            int stroka = 1;
            //шапка
            for (int i = 0; i < Shapka.Count; i++)
            {
                WS.Cells[stroka, 1] = Shapka[i];
                range = WS.get_Range("A" + stroka.ToString(), Opr.OpredelenieBukvi(Stolbci.Count) + stroka.ToString());
                range.Merge(Type.Missing);
                range.Font.Bold = true;
                range.Font.Size = 15;
                range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                range.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
                range.RowHeight = 25;
                range.WrapText = true;
                stroka++;
            }
            //заголовки
            for (int i = 0; i < Stolbci.Count; i++)
            {
                WS.Cells[stroka, i + 1] = Stolbci[i];
            }
            range = WS.get_Range("A" + stroka.ToString(), Opr.OpredelenieBukvi(Stolbci.Count) + stroka.ToString());
            range.Font.Bold = true;
            range.Font.Size = 13;
            range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            range.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
            range.RowHeight = 20;
            range.WrapText = true;
            int strokaOld = stroka;
            stroka++;



            //строки

            for (int j = 0; j < Stroki.Count; j++)
            {
                for (int i = 0; i < Stroki[j].Count; i++)
                {
                    WS.Cells[stroka, i + 1] = Stroki[j][i];
                }
                stroka++;
            }

            range = WS.get_Range("A" + strokaOld.ToString(), Opr.OpredelenieBukvi(Stolbci.Count) + (stroka).ToString());
            range.Font.Size = 13;
            range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            range.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
            range.RowHeight = 20;
            range.Columns.AutoFit();
            range.WrapText = true;
            range.Cells.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;



            // Сохранение файла Excel.

            WbExcel.SaveCopyAs(path);//сохраняем в папку

            ApExcel.Visible = true;//видимо
            ApExcel.ScreenUpdating = true;//обновляемо
                                          // Закрытие книги.
            WbExcel.Close(false, "", Type.Missing);
            // Закрытие приложения Excel.
            ApExcel.Quit();

            Marshal.FinalReleaseComObject(WbExcel);
            Marshal.FinalReleaseComObject(WB);
            Marshal.FinalReleaseComObject(ApExcel);
            GC.Collect();
            GC.WaitForPendingFinalizers();

        }


    }
    public class HouseToAkt
    {
        public string Adres = "";
        public List<string> pokazateli = new List<string>();
        public List<string> periodichnost = new List<string>();
        public List<decimal> StoimostNaM2 = new List<decimal>();
        public List<decimal> StoimostNaMonth = new List<decimal>();
        public int HId = 0;//ID текущего дома
        public List<int> UId = new List<int>();//ID услуг
    }
    //Загрузка стандартного файла эксель с поиском имен колонок в первых 30 на 30 клеток имена передаются массивом типа стринг.
    public class ExcelSVNUpload
    {


        public static void SaveToDocLog(int DvigenieId, int ItemId, string Opisanie, decimal QTY, int ToStock, int ToWork, string DocumentNumber)
        {
            try
            {
                DocumentLog L = new DocumentLog();
                L.DateStart = DateTime.Now;
                L.DvigenieId = DvigenieId;
                L.UserId = 0;
                L.ItemId = ItemId;
                L.Opisanie = Opisanie;
                L.QTY = QTY;
                L.ToStock = ToStock;
                L.ToWork = ToWork;
                L.FBillNo = DocumentNumber;
                using (var db = new KingDeeDB())
                {
                    db.DocumentLog.Add(L);
                    db.SaveChanges();
                }

            }
            catch (Exception e)
            {
                try
                {
                    DocumentLog L = new DocumentLog();
                    L.DateStart = DateTime.Now;

                    L.DvigenieId = 0;
                    L.UserId = 0;
                    L.ItemId = 0;
                    L.Opisanie = "Ошибка сохранения лога" + e.Message;
                    L.QTY = 0;
                    L.ToStock = 0;
                    L.ToWork = 0;
                    L.FBillNo = "";
                    using (var db = new KingDeeDB())
                    {
                        db.DocumentLog.Add(L);
                        db.SaveChanges();
                    }
                }
                catch
                {

                }
            }
        }


        //Универсальный метод загрузки требует          имя файла        наименования колонок  номер вкладки или наименование  ( массив номеров столбцов) по желанию
        public static List<List<string>> IMPORT(string FilePatch, string[] Names, out string Error, string Vkladka = "1", int[] X = null,  bool delete = true)
        {
            Error = "";
            List<List<string>> SVNKI = new List<List<string>>();
            //инициализация загруженного файла
            SaveToDocLog(0, 0, "Начато открытие EXCEL"+ FilePatch, 0, 0, 0, "");

            Excel.Application ApExcel = new Excel.Application();
            Excel.Workbooks WB = null;
            WB = ApExcel.Workbooks;
            Excel.Workbook WbExcel = null;
            try
            {

                WbExcel = WB.Open(FilePatch);
                SaveToDocLog(0, 0, "EXCEL открыт" + FilePatch, 0, 0, 0, "");
            }
            catch (Exception e)
            {
                //если вкладку не нашли
                // Закрытие книги.
                // WbExcel.Close(false, "", Type.Missing);
                // Закрытие приложения Excel.
                SaveToDocLog(0, 0, "При открытии EXCEL возникла ошибка " + e.Message, 0, 0, 0, "");
                ApExcel.Quit();

                //Marshal.FinalReleaseComObject(WbExcel);
                Marshal.FinalReleaseComObject(WB);
                Marshal.FinalReleaseComObject(ApExcel);
                GC.Collect();
                GC.WaitForPendingFinalizers();

                //Удаление файла с сервера
                File.Delete(FilePatch);
                Error = "Не найдена вкладка " + Vkladka;
                return SVNKI;

            }
            int vk = 1;
            string vks = "";
            bool Vkl = false;
            Excel.Worksheet WS = null;
            try
            {//если указана цифра вкладки то открываем ее
                vk = Convert.ToInt16(Vkladka);
                WS = WbExcel.Sheets[vk];
                Vkl = true;
                SaveToDocLog(0, 0, "Пытаемся открыть вкладку номер " + vk, 0, 0, 0, "");
            }
            catch
            {//если цифры нет то имя вкладки открываем
                try
                {
                    vks = Vkladka;
                    WS = (Excel.Worksheet)WbExcel.Worksheets[vks];
                    Vkl = true;
                    SaveToDocLog(0, 0, "Пытаемся открыть вкладку по имени " + vks, 0, 0, 0, "");
                }
                catch
                {
                    Error = "Нет такой вкладки в файле!" + Vkladka;
                    SaveToDocLog(0, 0, "Пытаемся открыть вкладку по имени " + vks, 0, 0, 0, "");
                    return SVNKI;
                }
            }
            if (Vkl == false) { Error = "Не найдена вкладка " + Vkladka; }
            Excel.Range range;//рэндж
            ApExcel.Visible = false;//невидимо
            ApExcel.ScreenUpdating = false;//и не обновляемо
            int stNumber = WS.UsedRange.Columns.Count;
            int startStroka = 1;
            //Создаем массив той же размерности
            int[] NamesI = new int[Names.Length];
            if (X != null)//если заданы столбцы числами то размерность будет Х
            {
                NamesI = new int[X.Length];
            }
            for (int N = 0; N < NamesI.Length; N++)
            {
                NamesI[N] = -1;//не найденные значения -1
                Names[N] = Names[N].Replace(" ", "").ToUpper();//Приводим все заголовки к виду без пробелов и верхний регистр

            }
            int progress = 0;
            double pro100 = WS.UsedRange.Rows.Count;
            int procount = 0;

            int lastRow = WS.UsedRange.Rows.Count;
            int LastCol = WS.UsedRange.Columns.Count;
            //range = WS.get_Range("A1", Opr.OpredelenieBukvi(lastRow)+"10");

            if (LastCol < Names.Length) { LastCol = Names.Length + 2; }//если вдруг количество столбцов криво определилось 
            int MaxX = 0;
            //Ищем максимальный X
            if (X!=null)
            try
            {
                    MaxX = X.Max(x => x);
                    LastCol = MaxX;
            }
            catch
            {

            }
            var EXX = new object[lastRow, LastCol];
            int rr = Convert.ToInt32(Convert.ToDecimal(lastRow) / 100);

            if (lastRow - rr * 100 < 0) { rr = rr - 1; }
            if (rr == 0) { rr = 1; }
            int rrr = lastRow - rr * 100;
            if (rrr < 0) { rrr = 0; }
            int lastrr = 0;
            int end = 100;
            if (lastRow <= 100) { end = lastRow; }

            for (int i = 1; i <= end; i++)//грузим из файла кусками объём файла \ 100
            {
                lastrr++;

                var EX = (object[,])WS.Range["A" + lastrr.ToString() + ":" + Opr.OpredelenieBukvi(LastCol) + (rr * i).ToString()].Value;
                for (int j = 0; j < rr; j++)
                {
                    for (int k = 0; k < LastCol; k++)
                    {

                        //сохраняем все строки экселя как объекты так намного быстрее затем обработаем
                        EXX[lastrr - 1 + j, k] = EX[j + 1, k + 1];

                    }
                }


                lastrr = rr * i;


            }
            var EX2 = (object[,])WS.Range["A" + (lastrr).ToString() + ":" + Opr.OpredelenieBukvi(LastCol) + (lastrr + rrr).ToString()].Value;//догружаем остатки
            for (int j = 0; j < rrr; j++)
            {
                for (int k = 0; k < LastCol; k++)
                {
                    EXX[lastrr - 1 + j, k] = EX2[j + 1, k + 1];
                }
            }

            //Загрузили теперь идем проверять шапку если она не задана изначально цифрами

            if (X == null)
            {
                for (int i = 0; i < 50; i++)
                {

                    for (int j = 0; j < LastCol; j++)
                    {
                        string EXL = "";
                        try
                        {
                            EXL = EXX[i, j].ToString();
                        }
                        catch { }
                        if (EXL.Equals("") == false)
                        {
                            string W = "";
                            try
                            {
                                W = EXL.ToString().Replace(" ", "").ToUpper();
                            }
                            catch
                            {

                            }
                            for (int n = 0; n < NamesI.Length; n++)
                            {
                                if (NamesI[n] < 0)
                                {
                                    if (Names[n].Equals(W))
                                    {//Заголовки уже в верхнем регистре и без пробелов поэтому и не приводим.
                                        startStroka = i;
                                        NamesI[n] = j;
                                        bool xx = true;
                                        foreach (int g in NamesI)
                                        {
                                            if (g < 0) { xx = false; break; }
                                        }

                                        if (xx)
                                        {
                                            goto ShapkaNaidena;
                                        }//если все заголовки нашли то выходим
                                        else
                                        {

                                            //если нашли соответствие то записали и вышли чтобы одинаковые наименования заголовков можно было далее назначить
                                            break;
                                        }
                                        //если вся шапка найдена то нафиг цикл идем к метке

                                    }

                                }


                            }
                        }


                    }
                    //если нашли все имена то выходим из цикла

                }
            }

            //Если не все заголовки найдены то смотрим каких не хватает и выдаем сообщение
            Error = "Не найдены заголовки: ";

            for (int g = 0; g < NamesI.Length; g++)
            {
                if (NamesI[g] < 0) { Error += Names[g] + "; "; }

            }

            ShapkaNaidena:
            //все ли найдены столбцы? Доп проверка много времени не займет.
            bool go = true;
            if (X == null)
            {
                foreach (int n in NamesI)
                {
                    if (n < 0)
                    {
                        go = false;
                    }
                }
            }
            else//если Х не нулевой то заполняем масив
            {
                for (int x = 0; x < X.Length; x++)
                {
                    NamesI[x] = X[x];
                }
            }

            //если все столбцы найдены то пишем данные
            if (go)
            {


                int Konec = 0;
                int Schetchik = 0;

                while (Konec <= 50 && Schetchik < lastRow - 1)
                {
                    Schetchik++;
                    if (startStroka >= lastRow - 1) { break; }
                    if (EXX[startStroka, NamesI[0]] != null)
                    {
                        Konec = 0;
                        List<string> L = new List<string>();
                        foreach (int j in NamesI)
                        {
                            string E = "0";
                            try
                            {
                                E = EXX[startStroka, j].ToString();
                            }
                            catch
                            {

                            }
                            L.Add(E);
                        }
                        SVNKI.Add(L);
                        procount++;
                        progress = Convert.ToInt16(procount / pro100 * 50);
                        ProgressHub.SendMessage("Загружаем файл... ", progress);
                        if (procount > pro100) { procount = Convert.ToInt32(pro100); }
                        startStroka++;
                    }
                    else
                    {
                        procount++;
                        progress = Convert.ToInt16(procount / pro100 * 50);
                        ProgressHub.SendMessage("Загружаем файл... ", progress);
                        if (procount > pro100) { procount = Convert.ToInt32(pro100); }
                        startStroka++;
                        Konec++;
                    }
                }

            }
            else
            {
                Console.WriteLine("Ничего не считано! Ошибка в файле.");
                ProgressHub.SendMessage("Ничего не считано! Ошибка в файле. ", 100);

            }

            //Грузим даты специально 
            try
            {
                SVNKI[0][0] = EXX[0, NamesI[1]].ToString();
                SVNKI[0][1] = EXX[0, NamesI[2]].ToString();
                SVNKI[0][2] = EXX[0, NamesI[3]].ToString();
            }
            catch
            {

            }

            // Закрытие книги.
            WbExcel.Close(false, "", Type.Missing);
            // Закрытие приложения Excel.

            ApExcel.Quit();

            Marshal.FinalReleaseComObject(WbExcel);
            Marshal.FinalReleaseComObject(WB);
            Marshal.FinalReleaseComObject(ApExcel);
            GC.Collect();
            GC.WaitForPendingFinalizers();

            //Удаление файла с сервера
            if (delete) {
                try
                {
                    File.Delete(FilePatch);
                }
                catch
                {

                }
                }


            return SVNKI;
        }

    }

    public class ExcelUpload
    {
        //при загрузке файла на сервер используем данный метод
        public static List<HouseToAkt> IMPORT(string FilePatch)
        {
            //инициализация загруженного файла
            Excel.Application ApExcel = new Excel.Application();
            Excel.Workbooks WB = null;
            WB = ApExcel.Workbooks;
            Excel.Workbook WbExcel = WB.Open(FilePatch);
            Excel.Worksheet WS = WbExcel.Sheets[1];
            Excel.Range range;//рэндж
            ApExcel.Visible = false;//невидимо
            ApExcel.ScreenUpdating = false;//и не обновляемо
            int stNumber = 0;
            int startStroka = 1;
            int stPeriod = 0;
            int stName = 0;
            int stDom = 0;
            List<bool> Krasnoe = new List<bool>();
            List<string> Name = new List<string>();
            List<string> Period = new List<string>();
            List<string> Homes = new List<string>();
            //находим ячейку со знаком № и от нее захватываем столбцы
            List<HouseToAkt> Houses = new List<HouseToAkt>();

            for (int i = 1; i < 11; i++)
            {
                for (int j = 1; j < 11; j++)
                {
                    string W = WS.Cells[i, j].Text;
                    if (W.Replace(" ", "").Equals("№"))
                    {
                        startStroka = i + 2;
                        stNumber = j;
                        stName = j + 1;
                        stPeriod = j + 2;
                        stDom = j + 3;
                        goto LoopEnd;

                    }
                }
            }
            LoopEnd:
            if (stName == 0)
            {

                return (Houses);
            }



            int k = startStroka;
            while (WS.Cells[k, stNumber].Interior.Color != ColorTranslator.ToOle(Color.White))
            {
                //Идем вниз по строкам и если первая ячейка не белая и в ней есть цифра то заносим ее в базу.
                string C = WS.Cells[k, stNumber].Text;
                try
                {
                    C = Convert.ToInt32(C).ToString();
                    if (WS.Cells[k, stNumber].Font.Color != ColorTranslator.ToOle(Color.Black))
                    {
                        Krasnoe.Add(true);
                    }
                    else
                    {
                        Krasnoe.Add(false);
                    }
                    string S1 = WS.Cells[k, stName].Text;
                    string S2 = WS.Cells[k, stPeriod].Text;

                    Name.Add(S1);
                    Period.Add(S2);
                }
                catch
                {

                }

                k++;
            }
            int h = stDom;

            int progress = 0;
            double pro100 = ApExcel.WorksheetFunction.CountA(WS.Columns[1]);
            int procount = 0;

            //грузим список домов из файла
            while (WS.Cells[startStroka - 2, h].Text != "")
            {
                procount++;
                progress = Convert.ToInt16(procount / pro100 * 50);
                ProgressHub.SendMessage("Загрузка...", progress);
                string s = WS.Cells[startStroka - 2, h].Text;
                s = s.Replace("пр.", "");
                s = s.Replace("проспект", "");
                s = s.Replace("просп.", "");
                s = s.Replace("проезд", "");
                s = s.Replace("Бульвар", "");
                s = s.Replace("Бульв.", "");
                // s = s.Replace("ТСЖ", ""); все что помечено ТСЖ мы не включаем в акт (Осадчук 17.01.19)
                s = ZachistkaStroki(s);
                HouseToAkt Hou = new HouseToAkt();
                Hou.Adres = s;
                Homes.Add(s);
                //добавим дом и сразу его заполним по стандарту
                for (int t = 0; t < Name.Count; t++)
                {
                    Hou.periodichnost.Add(Period[t]);
                    Hou.pokazateli.Add(Name[t]);

                    try
                    {
                        string ss = WS.Cells[startStroka + t, h].Text;
                        ss = ss.Replace(",", ".");
                        ss = ss.Replace(" ", "");
                        decimal dd = Convert.ToDecimal(ss);

                        //если помечена красным то
                        if (!Krasnoe[t])
                        {
                            if (dd != 0)
                            {
                                Hou.StoimostNaMonth.Add(dd / 12);
                            }
                            else
                            {
                                Hou.StoimostNaMonth.Add(0);
                            }
                        }
                        else
                        {
                            Hou.StoimostNaMonth.Add(dd);
                        }

                    }
                    catch
                    {
                        Hou.StoimostNaMonth.Add(0);
                    }

                    try
                    {
                        string ss = WS.Cells[startStroka + t, h + 1].Text;
                        ss = ss.Replace(" ", "");
                        ss = ss.Replace(",", ".");
                        Hou.StoimostNaM2.Add(Convert.ToDecimal(ss));
                    }
                    catch
                    {
                        Hou.StoimostNaM2.Add(0);
                    }
                }
                Houses.Add(Hou);

                h += 2;
            }
            // Закрытие Excel.

            // Закрытие книги.
            WbExcel.Close(false, "", Type.Missing);
            // Закрытие приложения Excel.

            ApExcel.Quit();

            Marshal.FinalReleaseComObject(WbExcel);
            Marshal.FinalReleaseComObject(WB);
            Marshal.FinalReleaseComObject(ApExcel);
            GC.Collect();
            GC.WaitForPendingFinalizers();

            //Удаление файла с сервера
            File.Delete(FilePatch);

            return (Houses);

            //Сохранение в БД полученных данных
        }
        public static string ZachistkaStroki(string S)
        {

            S = S.Replace(",", "");
            S = S.Replace(" ", "");
            S = S.Replace(".", "");
            S = S.Replace("-", "");
            S = S.ToUpper();
            return (S);

        }

    }


  



  


    
}