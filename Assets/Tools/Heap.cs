using System;
using System.Collections;
using System.Collections.Generic;


public interface IHeapItem<T> : IComparable<T>
{
    int HeapIndex
    {
        get;
        set;
    }
}
//对二叉堆进行泛型约束
public class Heap<T> where T : IHeapItem<T>
{
    T[] items;
    /// <summary>
    /// 当前树大小
    /// </summary>
    int currentItemCount;
    /// <summary>
    /// 指定树容量
    /// </summary>
    /// <param name="maxHeapSize"></param>
    public Heap(int maxHeapSize)
    {
        items = new T[maxHeapSize];
    }
    /// <summary>
    /// 加入新元素，向上排序
    /// </summary>
    /// <param name="item"></param>
    public void Add(T item)
    {
        //先插入到最后
        item.HeapIndex = currentItemCount;
        items[currentItemCount] = item;
        //向上排序
        SortUp(item);
        currentItemCount++;
    }
    /// <summary>
    /// 移除根节点，向下排序
    /// </summary>
    /// <returns></returns>
    public T RemoveFirst()
    {
        //根节点
        T firstItem = items[0];
        currentItemCount--;
        //把最后一个元素转移到第一个元素
        items[0] = items[currentItemCount];
        items[0].HeapIndex = 0;
        SortDown(items[0]);
        return firstItem;
    }
    /// <summary>
    /// 更新树重新排序
    /// </summary>
    /// <param name="item"></param>
    public void UpdateItem(T item)
    {
        SortUp(item);
    }
    /// <summary>
    /// 返回当前元素数量
    /// </summary>
    /// <returns></returns>
    public int Count()
    {
        return currentItemCount;
    }
    /// <summary>
    /// 是否存在元素
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public bool Contains(T item)
    {
        //比较传入和找到是否一样
        return Equals(items[item.HeapIndex], item);
    }
    /// <summary>
    /// 向下排序，寻找子节点
    /// </summary>
    /// <param name="item"></param>
    void SortDown(T item)
    {
        while (true)
        {
            //左叶
            int childIndexLeft = item.HeapIndex * 2 + 1;
            //右叶
            int childIndexRight = item.HeapIndex * 2 + 2;
            int swapIndex = 0;
            //如果还存在子节点 没有子节点返回
            if (childIndexLeft < currentItemCount)
            {
                swapIndex = childIndexLeft;
                if (childIndexRight < currentItemCount)
                {
                    //a.compareto(b) a<b=-1 a=b=0 a>b=1
                    if (items[childIndexLeft].CompareTo(items[childIndexRight]) > 0)
                    {
                        swapIndex = childIndexRight;//得到小的节点
                    }
                }
                //和小的节点比较 如果子节点大返回
                //a.compareto(b) a<b=-1 a=b=0 a>b=1
                if (item.CompareTo(items[swapIndex]) > 0)
                {
                    Swap(item, items[swapIndex]);
                }
                else
                {
                    return;
                }
            }
            else
            {
                return;
            }
        }
    }
    /// <summary>
    /// 向上排序，寻找父节点
    /// </summary>
    /// <param name="item"></param>
    void SortUp(T item)
    {
        //得到父节点
        int parentIndex = (int)((item.HeapIndex - 1) *0.5f);

        while (true)
        {
            T parentItem = items[parentIndex];
            //当前节点更小就交换
            //a.compareto(b) a<b=-1 a=b=0 a>b=1
            if (item.CompareTo(parentItem)<0)
            {
                Swap(item, parentItem);
            }
            else
            {
                break;
            }
            //继续向上比较
            parentIndex= (int)((item.HeapIndex - 1) * 0.5f);
        }
    }
    /// <summary>
    /// 交换树中的位置和数据
    /// </summary>
    void Swap(T itemA, T itemB)
    {
        items[itemA.HeapIndex] = itemB;
        items[itemB.HeapIndex] = itemA;

        int itemAIndex = itemA.HeapIndex;
        itemA.HeapIndex = itemB.HeapIndex;
        itemB.HeapIndex = itemAIndex;
    }
}
