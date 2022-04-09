using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LDJ50.KinUI
{
    [CreateAssetMenu(menuName = "LDJ50/Kin Cell Mapper", fileName = "newKinCellMapper.asset")]
    public class CellMapper : IInitializableSO
    {
        Dictionary<Vector2Int, Cell> map;

        public override void Initialize ()
        {
            map = new Dictionary<Vector2Int, Cell>();
        }

        public void RegisterCell (Vector2Int position, Cell cell)
        {
            if (map.TryGetValue(position, out Cell existing))
            {
                throw new InvalidOperationException($"mapper '{name}' already contains a cell '{existing.name}' at position {position}");
            }

            map[position] = cell;
        }

        public Cell GetCell (Vector2Int posiion) => map[posiion];
    }
}
