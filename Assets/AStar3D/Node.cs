using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node :IHeapItem<Node>{
    /// <summary>
    /// 是否可以通过此路径
    /// </summary>
    public bool _canWalk;
    /// <summary>
    /// 保存节点位置
    /// </summary>
    public Vector3 _worldPos;
    /// <summary>
    /// 整个网格的索引
    /// </summary>
    public int _gridX, _gridY;

    public int gCost;
    public int hCost;
    //指针
    int heapIndex;

    public int fCost
    {
        get { return gCost + hCost; }
    }
    /// <summary>
    /// 内部构造指针
    /// </summary>
    public int HeapIndex
    {
        get
        {
            return heapIndex;
        }

        set
        {
            heapIndex = value;
        }
    }

    public Node parent;

    public Node(bool _canWalk, Vector3 _worldPos, int _gridX, int _gridY)
    {
        this._canWalk = _canWalk;
        this._worldPos = _worldPos;
        this._gridX = _gridX;
        this._gridY = _gridY;
    }
    /// <summary>
    /// 比较估值
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public int CompareTo(Node nodeToCompare)
    {
        //a.compareto(b) a<b=-1 a=b=0 a>b=1
        int compare = fCost.CompareTo(nodeToCompare.fCost);
        if (compare==0)
        {
            compare = hCost.CompareTo(nodeToCompare.hCost);
        }
        return compare;
    }
}
