using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;

// Token: 0x02002D7E RID: 11646
[NullableContext(1)]
[Nullable(0)]
public class BulletActionContainer
{
	// Token: 0x060177E8 RID: 96232 RVA: 0x00682DB8 File Offset: 0x00680FB8
	public void Init(EBulletAction type, Type actionInfoClass, Type actionClass, bool isPersistentAction = false)
	{
		this.Type = type;
		this.ActionInfoClass = actionInfoClass;
		this.ActionClass = actionClass;
		this.IsPersistentAction = isPersistentAction;
		this.IsSimpleActionInfo = (this.ActionInfoClass == typeof(BulletActionInfoSimple));
		this.AllActionInfoList = new List<BulletActionInfoBase>();
		this.ActionInfoList = new List<BulletActionInfoBase>();
		BulletActionInfoBase bulletActionInfoBase = this.CreateActionInfo();
		bulletActionInfoBase.IsInPool = true;
		this.ActionInfoList.Add(bulletActionInfoBase);
		this.AllActionList = new List<BulletActionBase>();
		this.ActionList = new List<BulletActionBase>();
		BulletActionBase bulletActionBase = this.CreateAction();
		bulletActionBase.IsInPool = true;
		this.ActionList.Add(bulletActionBase);
	}

	// Token: 0x17001F00 RID: 7936
	// (get) Token: 0x060177E9 RID: 96233 RVA: 0x00682E5D File Offset: 0x0068105D
	public EBulletAction ActionType
	{
		get
		{
			return this.Type;
		}
	}

	// Token: 0x060177EA RID: 96234 RVA: 0x00682E68 File Offset: 0x00681068
	private BulletActionInfoBase CreateActionInfo()
	{
		BulletActionInfoBase bulletActionInfoBase = (BulletActionInfoBase)Activator.CreateInstance(this.ActionInfoClass, new object[]
		{
			this.Type
		});
		bulletActionInfoBase.Index = this.AllActionInfoList.Count;
		this.AllActionInfoList.Add(bulletActionInfoBase);
		return bulletActionInfoBase;
	}

	// Token: 0x060177EB RID: 96235 RVA: 0x00682EB8 File Offset: 0x006810B8
	public BulletActionInfoBase GetActionInfo()
	{
		if (this.IsSimpleActionInfo)
		{
			return this.ActionInfoList[0];
		}
		if (this.ActionInfoList.Count <= 0)
		{
			return this.CreateActionInfo();
		}
		BulletActionInfoBase bulletActionInfoBase = this.ActionInfoList[this.ActionInfoList.Count - 1];
		this.ActionInfoList.RemoveAt(this.ActionInfoList.Count - 1);
		bulletActionInfoBase.IsInPool = false;
		return bulletActionInfoBase;
	}

	// Token: 0x060177EC RID: 96236 RVA: 0x00682F28 File Offset: 0x00681128
	private BulletActionBase CreateAction()
	{
		BulletActionBase bulletActionBase = (BulletActionBase)Activator.CreateInstance(this.ActionClass, new object[]
		{
			this.Type
		});
		bulletActionBase.Index = this.AllActionList.Count;
		this.AllActionList.Add(bulletActionBase);
		return bulletActionBase;
	}

	// Token: 0x060177ED RID: 96237 RVA: 0x00682F78 File Offset: 0x00681178
	public BulletActionBase GetAction()
	{
		if (!this.IsPersistentAction)
		{
			return this.ActionList[0];
		}
		if (this.ActionList.Count <= 0)
		{
			return this.CreateAction();
		}
		BulletActionBase bulletActionBase = this.ActionList[this.ActionList.Count - 1];
		this.ActionList.RemoveAt(this.ActionList.Count - 1);
		bulletActionBase.IsInPool = false;
		return bulletActionBase;
	}

	// Token: 0x060177EE RID: 96238 RVA: 0x00682FE8 File Offset: 0x006811E8
	public void RecycleActionInfo(BulletActionInfoBase actionInfo)
	{
		if (this.IsSimpleActionInfo)
		{
			return;
		}
		if (actionInfo.IsInPool)
		{
			Singleton<Log>.Instance.Error(ELogModule.Bullet, ELogAuthor.CFT, "BulletActionInfo重复入池", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		actionInfo.Clear();
		actionInfo.IsInPool = true;
		this.ActionInfoList.Add(this.AllActionInfoList[actionInfo.Index]);
	}

	// Token: 0x060177EF RID: 96239 RVA: 0x0068304C File Offset: 0x0068124C
	public unsafe void RecycleAction(BulletActionBase action)
	{
		BulletActionInfoBase actionInfo = action.GetActionInfo();
		this.RecycleActionInfo(actionInfo);
		action.Clear();
		if (Singleton<BulletConstant>.Instance.OpenClearCheck)
		{
			foreach (PropertyInfo propertyInfo in actionInfo.GetType().GetProperties())
			{
				object value = propertyInfo.GetValue(actionInfo);
				Type propertyType = propertyInfo.PropertyType;
				if ((!(propertyType == typeof(int)) || (int)value != 0) && (!(propertyType == typeof(bool)) || (bool)value) && value != null && !(propertyInfo.Name == "Type") && !(propertyInfo.Name == "Index") && !(propertyInfo.Name == "IsInPool") && !(propertyInfo.Name == "Stat") && !(propertyInfo.Name == "TickStat") && !(propertyType.GetMethod("Invoke") != null))
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Bullet;
					ELogAuthor author = ELogAuthor.CFT;
					string message = "BulletActionInfo回收时，该变量不为undefined";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("type", actionInfo.Type);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("key", propertyInfo.Name);
					instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				}
			}
			foreach (PropertyInfo propertyInfo2 in action.GetType().GetProperties())
			{
				object value2 = propertyInfo2.GetValue(action);
				Type propertyType2 = propertyInfo2.PropertyType;
				if ((!(propertyType2 == typeof(int)) || (int)value2 != 0) && (!(propertyType2 == typeof(bool)) || (bool)value2) && value2 != null && !(propertyInfo2.Name == "Type") && !(propertyInfo2.Name == "Index") && !(propertyInfo2.Name == "IsInPool") && !(propertyInfo2.Name == "Stat") && !(propertyInfo2.Name == "TickStat") && !(propertyType2.GetMethod("Invoke") != null))
				{
					Log instance2 = Singleton<Log>.Instance;
					ELogModule module2 = ELogModule.Bullet;
					ELogAuthor author2 = ELogAuthor.CFT;
					string message2 = "BulletAction回收时，该变量不为undefined";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("type", action.Type);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("key", propertyInfo2.Name);
					instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
				}
			}
		}
		if (!this.IsPersistentAction)
		{
			return;
		}
		if (action.IsInPool)
		{
			Singleton<Log>.Instance.Error(ELogModule.Bullet, ELogAuthor.CFT, "BulletAction重复入池", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		action.IsInPool = true;
		this.ActionList.Add(this.AllActionList[action.Index]);
	}

	// Token: 0x0400B41E RID: 46110
	private EBulletAction Type;

	// Token: 0x0400B41F RID: 46111
	[Nullable(2)]
	private Type ActionInfoClass;

	// Token: 0x0400B420 RID: 46112
	[Nullable(2)]
	private Type ActionClass;

	// Token: 0x0400B421 RID: 46113
	private bool IsPersistentAction;

	// Token: 0x0400B422 RID: 46114
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<BulletActionInfoBase> AllActionInfoList;

	// Token: 0x0400B423 RID: 46115
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<BulletActionInfoBase> ActionInfoList;

	// Token: 0x0400B424 RID: 46116
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<BulletActionBase> AllActionList;

	// Token: 0x0400B425 RID: 46117
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<BulletActionBase> ActionList;

	// Token: 0x0400B426 RID: 46118
	private bool IsSimpleActionInfo;
}
