using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

// Token: 0x020022BF RID: 8895
[NullableContext(1)]
[Nullable(0)]
public class MotorcycleTreeTypeTabItem : CommonTabItemBase
{
	// Token: 0x06010D0A RID: 68874 RVA: 0x00499FF4 File Offset: 0x004981F4
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickToggle))
		};
	}

	// Token: 0x06010D0B RID: 68875 RVA: 0x0049A0C9 File Offset: 0x004982C9
	protected override void OnStart()
	{
		base.OnStart();
		this.SeqPlayer = new LevelSequencePlayer(base.GetItem(6));
	}

	// Token: 0x06010D0C RID: 68876 RVA: 0x0049A0E4 File Offset: 0x004982E4
	protected override void OnRefresh(CommonTabItemData data, bool isSelected, int gridIndex)
	{
		MotorcycleTreeTypeTabItemData motorcycleTreeTypeTabItemData = data as MotorcycleTreeTypeTabItemData;
		int treeType = motorcycleTreeTypeTabItemData.TreeType;
		bool isFinish = motorcycleTreeTypeTabItemData.IsFinish;
		bool flag = ModelBase<MotorcycleDevelopModel>.Instance.RedDotHasNewTechTree(treeType);
		MotorTechTree? motorTechTreeConfig = ConfigBase<MotorConfig>.Instance.GetMotorTechTreeConfig(treeType);
		if (motorTechTreeConfig == null)
		{
			return;
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), motorTechTreeConfig.Value.Name, Array.Empty<object>());
		base.SetTextureByPath(motorTechTreeConfig.Value.Icon, base.GetTexture(1), null, null);
		base.GetItem(3).SetUIActive(isFinish);
		base.GetItem(6).SetUIActive(flag);
		if (flag)
		{
			this.SeqPlayer.StopSequenceByKey("Loop", false, false);
			this.SeqPlayer.PlayLevelSequenceByName("Loop", false, null, false);
		}
	}

	// Token: 0x06010D0D RID: 68877 RVA: 0x0049A1BF File Offset: 0x004983BF
	private void OnClickToggle(EToggleState state)
	{
		if (state != EToggleState.ETT_Checked)
		{
			return;
		}
		Action<int> selectedCallBack = this.SelectedCallBack;
		if (selectedCallBack != null)
		{
			selectedCallBack(base.GridIndex);
		}
		base.GetItem(6).SetUIActive(false);
	}

	// Token: 0x06010D0E RID: 68878 RVA: 0x0049A1EC File Offset: 0x004983EC
	protected override void OnUpdateTabIcon(string iconPath)
	{
	}

	// Token: 0x06010D0F RID: 68879 RVA: 0x0049A1EE File Offset: 0x004983EE
	protected override void OnSetToggleState(EToggleState state, bool bFire)
	{
		base.GetExtendToggle(0).SetToggleStateForce(state, bFire, false, true);
	}

	// Token: 0x06010D10 RID: 68880 RVA: 0x0049A200 File Offset: 0x00498400
	protected override UUIExtendToggle GetTabToggle()
	{
		return base.GetExtendToggle(0);
	}

	// Token: 0x06010D11 RID: 68881 RVA: 0x0049A20C File Offset: 0x0049840C
	public void BindRedDot(ERedDotName redDotName, int treeType)
	{
		this.UnBindRedDot();
		UUIItem item = base.GetItem(4);
		this.RedDotName = new ERedDotName?(redDotName);
		this.TreeType = treeType;
		ControllerBase<RedDotController>.Instance.BindRedDot(redDotName, item, null, treeType);
	}

	// Token: 0x06010D12 RID: 68882 RVA: 0x0049A248 File Offset: 0x00498448
	public void UnBindRedDot()
	{
		if (this.RedDotName != null)
		{
			ControllerBase<RedDotController>.Instance.UnBindGivenUi(this.RedDotName.Value, base.GetItem(4), this.TreeType);
			this.RedDotName = null;
			this.TreeType = 0;
		}
	}

	// Token: 0x06010D13 RID: 68883 RVA: 0x0049A298 File Offset: 0x00498498
	public void BindNewRedDot(ERedDotName redDotName, int treeType)
	{
		this.UnBindNewRedDot();
		UUIItem item = base.GetItem(5);
		this.NewRedDotName = new ERedDotName?(redDotName);
		this.NewTreeType = treeType;
		ControllerBase<RedDotController>.Instance.BindRedDot(redDotName, item, null, treeType);
	}

	// Token: 0x06010D14 RID: 68884 RVA: 0x0049A2D4 File Offset: 0x004984D4
	public void UnBindNewRedDot()
	{
		if (this.NewRedDotName != null)
		{
			ControllerBase<RedDotController>.Instance.UnBindGivenUi(this.NewRedDotName.Value, base.GetItem(5), this.NewTreeType);
			this.NewRedDotName = null;
			this.NewTreeType = 0;
		}
	}

	// Token: 0x04008492 RID: 33938
	private ERedDotName? RedDotName;

	// Token: 0x04008493 RID: 33939
	private ERedDotName? NewRedDotName;

	// Token: 0x04008494 RID: 33940
	private int TreeType;

	// Token: 0x04008495 RID: 33941
	private int NewTreeType;

	// Token: 0x04008496 RID: 33942
	[Nullable(2)]
	private LevelSequencePlayer SeqPlayer;

	// Token: 0x0200857C RID: 34172
	[NullableContext(0)]
	private class EMotorTreeTypeTabItemComponent
	{
		// Token: 0x0402D2AD RID: 185005
		public const int TogItem = 0;

		// Token: 0x0402D2AE RID: 185006
		public const int TexIcon = 1;

		// Token: 0x0402D2AF RID: 185007
		public const int TxtName = 2;

		// Token: 0x0402D2B0 RID: 185008
		public const int FinishItem = 3;

		// Token: 0x0402D2B1 RID: 185009
		public const int RedDotItem = 4;

		// Token: 0x0402D2B2 RID: 185010
		public const int NewItem = 5;

		// Token: 0x0402D2B3 RID: 185011
		public const int NewSeqItem = 6;
	}
}
