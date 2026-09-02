using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001E96 RID: 7830
[NullableContext(1)]
[Nullable(0)]
public class MonsterHandBookItem : UiPanelBase, IDynamicScrollItem<MonsterHandBookDynamicData>
{
	// Token: 0x0600E785 RID: 59269 RVA: 0x003E85F4 File Offset: 0x003E67F4
	public UniTask Init(UUIItem actor)
	{
		MonsterHandBookItem.<Init>d__3 <Init>d__;
		<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<Init>d__.<>4__this = this;
		<Init>d__.actor = actor;
		<Init>d__.<>1__state = -1;
		<Init>d__.<>t__builder.Start<MonsterHandBookItem.<Init>d__3>(ref <Init>d__);
		return <Init>d__.<>t__builder.Task;
	}

	// Token: 0x0600E786 RID: 59270 RVA: 0x003E863F File Offset: 0x003E683F
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem))
		};
	}

	// Token: 0x0600E787 RID: 59271 RVA: 0x003E8678 File Offset: 0x003E6878
	private UniTask InitChildItem()
	{
		MonsterHandBookItem.<InitChildItem>d__5 <InitChildItem>d__;
		<InitChildItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitChildItem>d__.<>4__this = this;
		<InitChildItem>d__.<>1__state = -1;
		<InitChildItem>d__.<>t__builder.Start<MonsterHandBookItem.<InitChildItem>d__5>(ref <InitChildItem>d__);
		return <InitChildItem>d__.<>t__builder.Task;
	}

	// Token: 0x0600E788 RID: 59272 RVA: 0x003E86BB File Offset: 0x003E68BB
	[return: Nullable(2)]
	public AUIBaseActor GetUsingItem(MonsterHandBookDynamicData data)
	{
		if (!string.IsNullOrEmpty(data.TitleId))
		{
			return base.GetItem(0).GetOwner() as AUIBaseActor;
		}
		return base.GetItem(1).GetOwner() as AUIBaseActor;
	}

	// Token: 0x0600E789 RID: 59273 RVA: 0x003E86ED File Offset: 0x003E68ED
	public void ClearItem()
	{
		base.Destroy(null);
	}

	// Token: 0x0600E78A RID: 59274 RVA: 0x003E86F8 File Offset: 0x003E68F8
	public void Update(MonsterHandBookDynamicData data, int gridIndex)
	{
		if (this.MonsterHandBookTitleItem != null)
		{
			this.MonsterHandBookTitleItem.SetUiActive(false);
		}
		if (this.MonsterHandBookLayoutItem != null)
		{
			this.MonsterHandBookLayoutItem.SetUiActive(false);
		}
		if (!string.IsNullOrEmpty(data.TitleId))
		{
			if (this.MonsterHandBookTitleItem != null)
			{
				this.MonsterHandBookTitleItem.SetUiActive(true);
				this.MonsterHandBookTitleItem.Update(data.TitleId);
				return;
			}
		}
		else if (data.MonsterList != null && this.MonsterHandBookLayoutItem != null)
		{
			this.MonsterHandBookLayoutItem.SetUiActive(true);
			this.MonsterHandBookLayoutItem.Update(data.MonsterList);
		}
	}

	// Token: 0x04006F9A RID: 28570
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<UUIExtendToggle, int, bool> OnClickCallBack;

	// Token: 0x04006F9B RID: 28571
	[Nullable(2)]
	private MonsterHandBookTitleItem MonsterHandBookTitleItem;

	// Token: 0x04006F9C RID: 28572
	[Nullable(2)]
	private MonsterHandBookLayoutItem MonsterHandBookLayoutItem;
}
