﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneralFormLibrary1
{
    public class FormControl_DataAccess
    {
        public event EventHandler UpdateData;

        public static async Task<SortableBindingList<T>> GetSortableBindingListOfData<T>(Dictionary<string, string> credentials) where T : class
        {
            GeneralFormLibrary1.DataAccess<T> dataAccess = new DataAccess<T>(credentials);
            SortableBindingList<T> model = new SortableBindingList<T>(await dataAccess.GetAll());
            return model;
        }

        public async Task<int> AddNewRecordFromDataGridView<T>(Dictionary<string, string> credentials, DataGridView dataGridView, int RowIndex, string AppName) where T : class, new()
        {

            T newItem = new T();
            newItem = FormControls.DataGridViewToObject<T>(dataGridView, RowIndex);
            DataAccess<T> dataAccess = new DataAccess<T>(credentials);
            int id = -1;
            try
            {
                id = await dataAccess.Insert(newItem);

                //Fire event
                if (UpdateData != null)
                {
                    UpdateData(this, EventArgs.Empty);
                }

            }
            catch
            { }


            if (id > 0)
            {
                //Inserted
                //MessageBox.Show(null, "Record inserted", AppName);
            }
            else
            {
                MessageBox.Show(null, "Record failed to insert", AppName);
            }
            return id;
        }

    }
}
