using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using UnrealEngine;

// Token: 0x020024D5 RID: 9429
[NullableContext(1)]
[Nullable(0)]
public class PhantomInteractGridMediumItemGrid : MediumItemGrid
{
	// Token: 0x060124D8 RID: 74968 RVA: 0x0050838C File Offset: 0x0050658C
	public void Refresh(IPhantomInteractGridViewModel data, bool select, int gridIndex)
	{
		this.CurrentIndex = gridIndex;
		this.CurrentData = data;
		EMediumItemGridPhantomSpecialSkill value = EMediumItemGridPhantomSpecialSkill.Hide;
		if (data.IsSpecial)
		{
			if (data.IsInArea)
			{
				value = EMediumItemGridPhantomSpecialSkill.ShowAvailable;
			}
			else
			{
				value = EMediumItemGridPhantomSpecialSkill.ShowUnavailable;
			}
		}
		this.CurrentRedDot = (ModelBase<PhantomInteractModel>.Instance.CheckPhantomInteractUnlockRedDot(data.MonsterId) && data.InSlotIndex < 0);
		PhantomMediumItemGrid parameters = new PhantomMediumItemGrid
		{
			Data = data,
			MonsterId = new int?(data.MonsterInfoId),
			BottomTextId = data.Name,
			Level = new int?(data.Cost),
			IsLevelTextUseChangeColor = new bool?(true),
			SpecialSkill = new EMediumItemGridPhantomSpecialSkill?(value),
			IsDisable = new bool?(!data.IsUnlocked),
			SortNum = new int?(data.InSlotIndex + 1),
			IsRedDotVisible = new bool?(this.CurrentRedDot),
			QualityId = new int?(1)
		};
		base.SetUseFixedAsync(true);
		base.Apply<PhantomMediumItemGrid>(parameters);
	}

	// Token: 0x060124D9 RID: 74969 RVA: 0x00508488 File Offset: 0x00506688
	protected override void OnStart()
	{
		base.BindOnExtendToggleStateChanged(new Action<MediumItemGridExtendCallback>(this.OnClickEvent));
	}

	// Token: 0x060124DA RID: 74970 RVA: 0x0050849C File Offset: 0x0050669C
	private void OnClickEvent(MediumItemGridExtendCallback callback)
	{
		if (callback.State != EToggleState.ETT_Checked)
		{
			this.GetItemGridExtendToggle().SetToggleState(EToggleState.ETT_Checked, false, false, false);
			return;
		}
		if (this.OnClickCallBack != null && this.CurrentData != null)
		{
			this.OnClickCallBack(this.CurrentData, this.CurrentIndex);
		}
	}

	// Token: 0x060124DB RID: 74971 RVA: 0x005084EA File Offset: 0x005066EA
	public void SetOnClickCallBack(Action<IPhantomInteractGridViewModel, int> call)
	{
		this.OnClickCallBack = call;
	}

	// Token: 0x04008EC6 RID: 36550
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Action<IPhantomInteractGridViewModel, int> OnClickCallBack;

	// Token: 0x04008EC7 RID: 36551
	private int CurrentIndex = -1;

	// Token: 0x04008EC8 RID: 36552
	[Nullable(2)]
	private IPhantomInteractGridViewModel CurrentData;

	// Token: 0x04008EC9 RID: 36553
	private bool CurrentRedDot;
}
