using System;
using System.Windows.Forms;
using System.Data;

namespace Lab1
{
    internal class MatrMake
    {
        int n_str, //количество строк
        n_col; //количество столбцов
        int[,] matrix; // обрабатываемая матрица
        public MatrMake(int n, int m)
        {
            n_str = n;
            n_col = m;
            matrix = new int[n, m];
        }

        public int get_col()
        {
            return n_col;
        }

        public int get_str()
        {
            return n_str;
        }
        //заполнение матрицы из DataGridView
        public void GridToMatrix(DataGridView dgv)
        {
            DataGridViewCell txtCell;
            for (int i = 0; i < n_str; i++)
            {
                for (int j = 0; j < n_col; j++)
                {
                    txtCell = dgv.Rows[i].Cells[j];
                    //txtCell = dgv.Columns[i].Cells[j];
                    string s = txtCell.Value.ToString();
                    if (s == "")
                        matrix[i, j] = 0;
                    else
                        matrix[i, j] = Int32.Parse(s);
                }
            }
        }
        //вывод матрицы в DataGridView
        public void MatrixToGrid(DataGridView dgv)
        {
            //установка размеров
            int i;
            DataTable matr = new DataTable("matr");
            DataColumn[] cols = new DataColumn[n_col];
            for (i = 0; i < n_col; i++)
            {
                cols[i] = new DataColumn(i.ToString());
                matr.Columns.Add(cols[i]);
            }
            for (i = 0; i < n_str; i++)
            {
                DataRow newRow;
                newRow = matr.NewRow();
                matr.Rows.Add(newRow);
            }
            dgv.DataSource = matr;
            for (i = 0; i < n_col; i++)
                dgv.Columns[i].Width = 50;
            // занесение значений
            DataGridViewCell txtCell;
            for (i = 0; i < n_str; i++)
            {
                for (int j = 0; j < n_col; j++)
                {
                    txtCell = dgv.Rows[i].Cells[j];
                    txtCell.Value = matrix[i, j].ToString();
                }
            }
        }
        public bool DelCol(int del_number)
        {
            int i, j;
            bool ok;
            ok = true;
            for (j = 0; j < n_col && ok; j++)
                if (j == del_number)
                    ok = false;
            if (!ok)
            {
                for (i = 0; i < n_str; i++)
                    for (j = del_number; j < n_col - 1; j++)
                        matrix[i, j] = matrix[i, j + 1];
                n_col--;
                ok = true;
            }
            return ok;
        }
    }
}
