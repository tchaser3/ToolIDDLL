/* Title:           Tool ID Class
 * Date:            6-12-+18
 * Authour:         Terry Holmes
 * 
 * Description:     This is used for Tool ID */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewEventLogDLL;

namespace ToolIDDLL
{
    public class ToolIDClass
    {
        EventLogClass TheEventLogClass = new EventLogClass();

        ToolIDDataSet aToolIDDataSet;
        ToolIDDataSetTableAdapters.toolidTableAdapter aToolIDTableAdapter;

        UpdateToolIDEntryTableAdapters.QueriesTableAdapter aUpdateToolIDTableAdapter;

        FindToolIDByCategoryDataSet aFindToolIDByCategoryDataSet;
        FindToolIDByCategoryDataSetTableAdapters.FindToolIDByCategoryTableAdapter aFindToolIDByCategoryTableAdapter;

        InsertToolIDEntryTableAdapters.QueriesTableAdapter aInsertToolIDTableAdapter;

        public FindToolIDByCategoryDataSet FindToolIDByCategory(string strCategory)
        {
            try
            {
                aFindToolIDByCategoryDataSet = new FindToolIDByCategoryDataSet();
                aFindToolIDByCategoryTableAdapter = new FindToolIDByCategoryDataSetTableAdapters.FindToolIDByCategoryTableAdapter();
                aFindToolIDByCategoryTableAdapter.Fill(aFindToolIDByCategoryDataSet.FindToolIDByCategory, strCategory);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Tool ID Class // Find Tool ID By Category " + Ex.Message);
            }

            return aFindToolIDByCategoryDataSet;
        }
        public bool UpdateToolID(int intTransactionID, string strToolID)
        {
            bool blnFatalError = false;

            try
            {
                aUpdateToolIDTableAdapter = new UpdateToolIDEntryTableAdapters.QueriesTableAdapter();
                aUpdateToolIDTableAdapter.UpdateToolID(intTransactionID, strToolID);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Tool ID Class // Update Tool ID " + Ex.Message);

                blnFatalError = true;
            }

            return blnFatalError;
        } 
        public ToolIDDataSet GetToolIDInfo()
        {
            try
            {
                aToolIDDataSet = new ToolIDDataSet();
                aToolIDTableAdapter = new ToolIDDataSetTableAdapters.toolidTableAdapter();
                aToolIDTableAdapter.Fill(aToolIDDataSet.toolid);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Tool ID Class // Get Tool ID info " + Ex.Message);
            }

            return aToolIDDataSet;
        }
        public void UpdateToolIDDB(ToolIDDataSet aToolIDDataSet)
        {
            try
            {
                aToolIDTableAdapter = new ToolIDDataSetTableAdapters.toolidTableAdapter();
                aToolIDTableAdapter.Update(aToolIDDataSet.toolid);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Tool ID Class // Update Tool ID DB " + Ex.Message);
            }
        }
        public bool InsertNewToolIDForToolType(int intCategoryID, string strToolID)
        {
            bool blnFatalError = false;

            try
            {
                aInsertToolIDTableAdapter = new InsertToolIDEntryTableAdapters.QueriesTableAdapter();
                aInsertToolIDTableAdapter.InsertToolID(intCategoryID, strToolID);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Tool ID Class // Insert New Tool ID for Tool Type " + Ex.Message);

                blnFatalError = true;
            }

            return blnFatalError;
        }
        
    }
}
