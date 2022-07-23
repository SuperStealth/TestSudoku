using UnityEngine;

namespace Sudoku
{
    public class FieldView : MonoBehaviour
    {
        [SerializeField] private RowView[] rows;

        public void UpdateView(Field field)
        {
            for (int i = 0; i < rows.Length; i++)
            {
                for (int j = 0; j < rows[i].CellViews.Length; j++)
                {
                    int cellValue = field.GetCell(i, j);
                    if (cellValue != 0)
                    {
                        rows[i].CellViews[j].SetCellValue(cellValue);
                    }                  
                }
            }
        }
    }
}

