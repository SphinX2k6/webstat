using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001AD4 RID: 6868
[NullableContext(2)]
[Nullable(0)]
public class DangoAbyssAttributeParentItem : UiPanelBase, IDynamicScrollItem<DangoAbyssDefine.EquipViewAttributeData>
{
	// Token: 0x0600C5A1 RID: 50593 RVA: 0x00343338 File Offset: 0x00341538
	[NullableContext(1)]
	public UniTask Init(UUIItem actor)
	{
		DangoAbyssAttributeParentItem.<Init>d__4 <Init>d__;
		<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<Init>d__.<>4__this = this;
		<Init>d__.actor = actor;
		<Init>d__.<>1__state = -1;
		<Init>d__.<>t__builder.Start<DangoAbyssAttributeParentItem.<Init>d__4>(ref <Init>d__);
		return <Init>d__.<>t__builder.Task;
	}

	// Token: 0x0600C5A2 RID: 50594 RVA: 0x00343384 File Offset: 0x00341584
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem))
		};
	}

	// Token: 0x0600C5A3 RID: 50595 RVA: 0x003433E0 File Offset: 0x003415E0
	[NullableContext(1)]
	public AUIBaseActor GetUsingItem(DangoAbyssDefine.EquipViewAttributeData data)
	{
		if (data.Attribute != null)
		{
			return base.GetItem(1).GetOwner() as AUIBaseActor;
		}
		if (data.Tag != null)
		{
			return base.GetItem(2).GetOwner() as AUIBaseActor;
		}
		return base.GetItem(0).GetOwner() as AUIBaseActor;
	}

	// Token: 0x0600C5A4 RID: 50596 RVA: 0x00343434 File Offset: 0x00341634
	protected override void OnStart()
	{
		this.ItemTitle = new DangoAbyssAttributeTitleItem();
		this.ItemTitle.Initialize(base.GetItem(0));
		this.ItemAttribute = new DangoAbyssAttributeItem();
		this.ItemAttribute.Initialize(base.GetItem(1));
		this.ItemTag = new DangoAbyssAttributeTagItem();
		this.ItemTag.Initialize(base.GetItem(2));
	}

	// Token: 0x0600C5A5 RID: 50597 RVA: 0x00343498 File Offset: 0x00341698
	[NullableContext(1)]
	public void Update(DangoAbyssDefine.EquipViewAttributeData data, int index)
	{
		this.Data = data;
		this.ItemAttribute.SetUiActive(false);
		this.ItemTag.SetUiActive(false);
		this.ItemTitle.SetUiActive(false);
		if (data.Attribute != null)
		{
			this.ItemAttribute.Refresh(data);
			return;
		}
		if (data.Tag != null)
		{
			this.ItemTag.Refresh(data);
			return;
		}
		this.ItemTitle.Refresh(data);
	}

	// Token: 0x0600C5A6 RID: 50598 RVA: 0x00343508 File Offset: 0x00341708
	public void ClearItem()
	{
		this.Data = null;
		DangoAbyssAttributeTitleItem itemTitle = this.ItemTitle;
		if (itemTitle != null)
		{
			itemTitle.Destroy(null);
		}
		this.ItemTitle = null;
		DangoAbyssAttributeItem itemAttribute = this.ItemAttribute;
		if (itemAttribute != null)
		{
			itemAttribute.Destroy(null);
		}
		this.ItemAttribute = null;
		DangoAbyssAttributeTagItem itemTag = this.ItemTag;
		if (itemTag != null)
		{
			itemTag.Destroy(null);
		}
		this.ItemTag = null;
	}

	// Token: 0x04005EB8 RID: 24248
	public DangoAbyssDefine.EquipViewAttributeData Data;

	// Token: 0x04005EB9 RID: 24249
	public DangoAbyssAttributeTitleItem ItemTitle;

	// Token: 0x04005EBA RID: 24250
	public DangoAbyssAttributeItem ItemAttribute;

	// Token: 0x04005EBB RID: 24251
	public DangoAbyssAttributeTagItem ItemTag;
}
