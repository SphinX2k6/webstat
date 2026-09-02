using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002AAB RID: 10923
[NullableContext(2)]
[Nullable(0)]
public class SubPackageDownLoadItem : UiPanelBase, IDynamicScrollItem<SubPackageDownLoadDynamicData>
{
	// Token: 0x06015DB7 RID: 89527 RVA: 0x00610B0C File Offset: 0x0060ED0C
	[NullableContext(1)]
	public UniTask Init(UUIItem actor)
	{
		SubPackageDownLoadItem.<Init>d__7 <Init>d__;
		<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<Init>d__.<>4__this = this;
		<Init>d__.actor = actor;
		<Init>d__.<>1__state = -1;
		<Init>d__.<>t__builder.Start<SubPackageDownLoadItem.<Init>d__7>(ref <Init>d__);
		return <Init>d__.<>t__builder.Task;
	}

	// Token: 0x06015DB8 RID: 89528 RVA: 0x00610B58 File Offset: 0x0060ED58
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem))
		};
	}

	// Token: 0x06015DB9 RID: 89529 RVA: 0x00610BB4 File Offset: 0x0060EDB4
	[NullableContext(1)]
	[return: Nullable(2)]
	public AUIBaseActor GetUsingItem(SubPackageDownLoadDynamicData data)
	{
		if (data.Type != null && data.Type.Value != (ESubPackageDownLoadVersionType)0)
		{
			return base.GetItem(0).GetOwner() as AUIBaseActor;
		}
		if (data.VersionId != null && data.VersionId.Value != 0)
		{
			return base.GetItem(1).GetOwner() as AUIBaseActor;
		}
		return base.GetItem(2).GetOwner() as AUIBaseActor;
	}

	// Token: 0x06015DBA RID: 89530 RVA: 0x00610C2C File Offset: 0x0060EE2C
	[NullableContext(1)]
	public void Update(SubPackageDownLoadDynamicData data, int index)
	{
		this.Data = data;
		SubPackageDownLoadTitleItem subPackageDownLoadTitleItem = this.SubPackageDownLoadTitleItem;
		if (subPackageDownLoadTitleItem != null)
		{
			subPackageDownLoadTitleItem.SetUiActive(false);
		}
		SubPackageDownLoadVersionItem subPackageDownLoadVersionItem = this.SubPackageDownLoadVersionItem;
		if (subPackageDownLoadVersionItem != null)
		{
			subPackageDownLoadVersionItem.SetUiActive(false);
		}
		SubPackageDownLoadSubPackageItem subPackageDownLoadSubPackageItem = this.SubPackageDownLoadSubPackageItem;
		if (subPackageDownLoadSubPackageItem != null)
		{
			subPackageDownLoadSubPackageItem.SetUiActive(false);
		}
		if (data.Type != null && data.Type.Value != (ESubPackageDownLoadVersionType)0)
		{
			SubPackageDownLoadTitleItem subPackageDownLoadTitleItem2 = this.SubPackageDownLoadTitleItem;
			if (subPackageDownLoadTitleItem2 != null)
			{
				subPackageDownLoadTitleItem2.SetUiActive(true);
			}
			SubPackageDownLoadTitleItem subPackageDownLoadTitleItem3 = this.SubPackageDownLoadTitleItem;
			if (subPackageDownLoadTitleItem3 == null)
			{
				return;
			}
			subPackageDownLoadTitleItem3.RefreshItem(data.Type.Value);
			return;
		}
		else
		{
			if (data.VersionId == null || data.VersionId.Value == 0)
			{
				if (data.SubPackageId != null && data.SubPackageId.Value != 0)
				{
					SubPackageDownLoadSubPackageItem subPackageDownLoadSubPackageItem2 = this.SubPackageDownLoadSubPackageItem;
					if (subPackageDownLoadSubPackageItem2 != null)
					{
						subPackageDownLoadSubPackageItem2.SetUiActive(true);
					}
					SubPackageDownLoadSubPackageItem subPackageDownLoadSubPackageItem3 = this.SubPackageDownLoadSubPackageItem;
					if (subPackageDownLoadSubPackageItem3 == null)
					{
						return;
					}
					subPackageDownLoadSubPackageItem3.RefreshItem(data.SubPackageId.Value);
				}
				return;
			}
			SubPackageDownLoadVersionItem subPackageDownLoadVersionItem2 = this.SubPackageDownLoadVersionItem;
			if (subPackageDownLoadVersionItem2 != null)
			{
				subPackageDownLoadVersionItem2.SetUiActive(true);
			}
			SubPackageDownLoadVersionItem subPackageDownLoadVersionItem3 = this.SubPackageDownLoadVersionItem;
			if (subPackageDownLoadVersionItem3 == null)
			{
				return;
			}
			subPackageDownLoadVersionItem3.RefreshItem(data.VersionId.Value, data.IsShowItem);
			return;
		}
	}

	// Token: 0x06015DBB RID: 89531 RVA: 0x00610D54 File Offset: 0x0060EF54
	private UniTask InitChildItem()
	{
		SubPackageDownLoadItem.<InitChildItem>d__11 <InitChildItem>d__;
		<InitChildItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitChildItem>d__.<>4__this = this;
		<InitChildItem>d__.<>1__state = -1;
		<InitChildItem>d__.<>t__builder.Start<SubPackageDownLoadItem.<InitChildItem>d__11>(ref <InitChildItem>d__);
		return <InitChildItem>d__.<>t__builder.Task;
	}

	// Token: 0x06015DBC RID: 89532 RVA: 0x00610D97 File Offset: 0x0060EF97
	public void RefreshDownLoadState()
	{
		SubPackageDownLoadVersionItem subPackageDownLoadVersionItem = this.SubPackageDownLoadVersionItem;
		if (subPackageDownLoadVersionItem != null)
		{
			subPackageDownLoadVersionItem.RefreshDownLoadStateByTime();
		}
		SubPackageDownLoadSubPackageItem subPackageDownLoadSubPackageItem = this.SubPackageDownLoadSubPackageItem;
		if (subPackageDownLoadSubPackageItem == null)
		{
			return;
		}
		subPackageDownLoadSubPackageItem.RefreshDownLoadStateByTime();
	}

	// Token: 0x06015DBD RID: 89533 RVA: 0x00610DBA File Offset: 0x0060EFBA
	public void ClearItem()
	{
		base.Destroy(null);
	}

	// Token: 0x06015DBE RID: 89534 RVA: 0x00610DC3 File Offset: 0x0060EFC3
	public SubPackageDownLoadDynamicData GetData()
	{
		return this.Data;
	}

	// Token: 0x06015DBF RID: 89535 RVA: 0x00610DCC File Offset: 0x0060EFCC
	[NullableContext(1)]
	public UUIItem GetInteractItem()
	{
		SubPackageDownLoadDynamicData data = this.Data;
		if (data != null && data.VersionId != null && this.Data.VersionId.Value != 0)
		{
			return this.SubPackageDownLoadVersionItem.GetToggleItem();
		}
		return this.SubPackageDownLoadSubPackageItem.GetBtnItem();
	}

	// Token: 0x06015DC0 RID: 89536 RVA: 0x00610E1B File Offset: 0x0060F01B
	protected void OnChildItemClickBtn()
	{
		if (this.Data != null)
		{
			Action<SubPackageDownLoadDynamicData> onClickBtnCallBack = this.OnClickBtnCallBack;
			if (onClickBtnCallBack == null)
			{
				return;
			}
			onClickBtnCallBack(this.Data);
		}
	}

	// Token: 0x0400A7B0 RID: 42928
	protected SubPackageDownLoadDynamicData Data;

	// Token: 0x0400A7B1 RID: 42929
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<SubPackageDownLoadDynamicData> OnClickBtnCallBack;

	// Token: 0x0400A7B2 RID: 42930
	public Action<int, bool> OnClickCallBack;

	// Token: 0x0400A7B3 RID: 42931
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<int, UUIItem> OnClickHelpBtnCallBack;

	// Token: 0x0400A7B4 RID: 42932
	private SubPackageDownLoadTitleItem SubPackageDownLoadTitleItem;

	// Token: 0x0400A7B5 RID: 42933
	private SubPackageDownLoadVersionItem SubPackageDownLoadVersionItem;

	// Token: 0x0400A7B6 RID: 42934
	private SubPackageDownLoadSubPackageItem SubPackageDownLoadSubPackageItem;
}
