using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using UnrealEngine;

// Token: 0x02002D40 RID: 11584
public class WeeklyRogueTokenInfoGrid : LoopScrollMediumItemGrid<int>
{
	// Token: 0x17001EC3 RID: 7875
	// (get) Token: 0x060175E6 RID: 95718 RVA: 0x0067AE2B File Offset: 0x0067902B
	// (set) Token: 0x060175E7 RID: 95719 RVA: 0x0067AE38 File Offset: 0x00679038
	public new int Data
	{
		get
		{
			return (int)this.Data;
		}
		set
		{
			this.Data = value;
		}
	}

	// Token: 0x060175E8 RID: 95720 RVA: 0x0067AE46 File Offset: 0x00679046
	public WeeklyRogueTokenInfoGrid()
	{
		this.Data = 0;
	}

	// Token: 0x060175E9 RID: 95721 RVA: 0x0067AE58 File Offset: 0x00679058
	protected override void OnRefresh(int data, bool isSelected, int gridIndex)
	{
		this.Data = data;
		if (data == 0)
		{
			PhantomMediumItemGrid parameters = new PhantomMediumItemGrid
			{
				Data = data,
				IsPhantomLock = new bool?(true),
				BottomTextId = "WeRogueMisssingToken"
			};
			base.Apply<PhantomMediumItemGrid>(parameters);
			base.SetToggleInteractive(false);
			return;
		}
		RogueWeeklyBuffPool? rogueWeeklyBuffPool = ConfigBase<WeeklyRogueConfig>.Instance.GetRogueWeeklyBuffPool(data);
		if (rogueWeeklyBuffPool == null)
		{
			return;
		}
		PropMediumItemGrid parameters2 = new PropMediumItemGrid
		{
			Data = data,
			IconPath = rogueWeeklyBuffPool.Value.BuffIcon,
			QualityId = new int?(rogueWeeklyBuffPool.Value.Quality),
			QualityType = new CommonDefine.EQualityIconType?(CommonDefine.EQualityIconType.MediumItemGridQualitySpritePath),
			BottomTextId = rogueWeeklyBuffPool.Value.BuffName
		};
		base.Apply<PropMediumItemGrid>(parameters2);
		base.SetToggleInteractive(true);
	}

	// Token: 0x060175EA RID: 95722 RVA: 0x0067AF2D File Offset: 0x0067912D
	protected override void OnExtendToggleStateChanged(EToggleState state)
	{
		Action<int, bool> onSelectedChange = this.OnSelectedChange;
		if (onSelectedChange == null)
		{
			return;
		}
		onSelectedChange(this.Data, state == EToggleState.ETT_Checked);
	}

	// Token: 0x060175EB RID: 95723 RVA: 0x0067AF49 File Offset: 0x00679149
	public override void OnSelected(bool fireEvent)
	{
		this.SetSelected(true, false);
		if (fireEvent)
		{
			Action<int, bool> onSelectedChange = this.OnSelectedChange;
			if (onSelectedChange == null)
			{
				return;
			}
			onSelectedChange(this.Data, true);
		}
	}

	// Token: 0x060175EC RID: 95724 RVA: 0x0067AF6D File Offset: 0x0067916D
	public override void OnDeselected(bool fireEvent)
	{
		this.SetSelected(false, false);
	}

	// Token: 0x060175ED RID: 95725 RVA: 0x0067AF77 File Offset: 0x00679177
	[NullableContext(1)]
	public override object GetKey(int data, int gridIndex)
	{
		return this.Data;
	}

	// Token: 0x0400B36C RID: 45932
	[Nullable(2)]
	public Action<int, bool> OnSelectedChange;
}
