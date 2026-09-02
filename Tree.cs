using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02000077 RID: 119
[NullableContext(1)]
[Nullable(0)]
public class Tree<[Nullable(2)] T>
{
	// Token: 0x060002D6 RID: 726 RVA: 0x0000F824 File Offset: 0x0000DA24
	public Tree(T element, [Nullable(new byte[]
	{
		2,
		1
	})] Tree<T> parent = null)
	{
		this.Element = element;
		this.Parent = parent;
	}

	// Token: 0x17000060 RID: 96
	// (get) Token: 0x060002D7 RID: 727 RVA: 0x0000F83A File Offset: 0x0000DA3A
	public Dictionary<T, Tree<T>> ChildMap
	{
		get
		{
			if (this.ChildMapInternal == null)
			{
				this.ChildMapInternal = new Dictionary<T, Tree<T>>();
			}
			return this.ChildMapInternal;
		}
	}

	// Token: 0x060002D8 RID: 728 RVA: 0x0000F858 File Offset: 0x0000DA58
	public void AddChild(Tree<T> child)
	{
		T element = child.Element;
		if (this.ChildMap.ContainsKey(element))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.RedDot;
			ELogAuthor author = ELogAuthor.TL;
			string message = "重复添加子节点！";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("element", element);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		child.Parent = this;
		this.ChildMap[element] = child;
	}

	// Token: 0x060002D9 RID: 729 RVA: 0x0000F8BC File Offset: 0x0000DABC
	public void AddChildElement(T element)
	{
		if (this.ChildMap.ContainsKey(element))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.RedDot;
			ELogAuthor author = ELogAuthor.TL;
			string message = "重复添加子节点！";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("element", element);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		Tree<T> tree = new Tree<T>(element, this);
		tree.Parent = this;
		this.ChildMap[element] = tree;
	}

	// Token: 0x060002DA RID: 730 RVA: 0x0000F920 File Offset: 0x0000DB20
	public void AddParent(Tree<T> parent)
	{
		if (this.Parent != null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.RedDot;
			ELogAuthor author = ELogAuthor.TL;
			string message = "该节点已存在父节点！";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("element", this.Element);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		this.Parent = parent;
		parent.ChildMap[this.Element] = this;
	}

	// Token: 0x060002DB RID: 731 RVA: 0x0000F980 File Offset: 0x0000DB80
	public void AddParentElement(T element)
	{
		if (this.Parent != null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.RedDot;
			ELogAuthor author = ELogAuthor.TL;
			string message = "该节点已存在父节点！";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("element", this.Element);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		this.Parent = new Tree<T>(element, null);
		this.Parent.ChildMap[this.Element] = this;
	}

	// Token: 0x060002DC RID: 732 RVA: 0x0000F9EB File Offset: 0x0000DBEB
	public Tree<T> GetRoot()
	{
		if (this.Parent == null)
		{
			return this;
		}
		return this.Parent.GetRoot();
	}

	// Token: 0x060002DD RID: 733 RVA: 0x0000FA02 File Offset: 0x0000DC02
	public bool IsRoot()
	{
		return this.Parent == null;
	}

	// Token: 0x060002DE RID: 734 RVA: 0x0000FA0D File Offset: 0x0000DC0D
	public bool IsLeaf()
	{
		return this.ChildMap.Count <= 0;
	}

	// Token: 0x04000206 RID: 518
	public T Element;

	// Token: 0x04000207 RID: 519
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Tree<T> Parent;

	// Token: 0x04000208 RID: 520
	[Nullable(new byte[]
	{
		2,
		1,
		1,
		1
	})]
	private Dictionary<T, Tree<T>> ChildMapInternal;
}
