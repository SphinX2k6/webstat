using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.SkipInterface;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200228C RID: 8844
[Nullable(new byte[]
{
	0,
	1
})]
public class MotorcycleConditionItem : GridProxyAbstract<IMotorLevelConditionData>
{
	// Token: 0x06010B8C RID: 68492 RVA: 0x00494374 File Offset: 0x00492574
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIText)),
			new ValueTuple<int, Type>(5, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIButtonComponent))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(5, new Action(this.ButtonJumpClick)),
			new ValueTuple<int, Delegate>(8, new Action(this.ButtonJumpClick))
		};
	}

	// Token: 0x06010B8D RID: 68493 RVA: 0x00494490 File Offset: 0x00492690
	[NullableContext(1)]
	public override void Refresh(IMotorLevelConditionData data, bool isSelected, int gridIndex)
	{
		this.Data = data;
		bool flag = data.AccessType == 1;
		bool flag2 = data.AccessType == 3;
		UUIText text = base.GetText(4);
		if (!StringUtils.IsEmpty(data.ConditionTextId))
		{
			text.ShowTextNew(data.ConditionTextId);
		}
		else
		{
			text.SetText("", true);
		}
		base.GetItem(1).SetUIActive(flag);
		base.GetItem(2).SetUIActive(!flag);
		base.GetItem(3).SetUIActive(true);
		base.GetItem(6).SetUIActive(false);
		base.GetItem(7).SetUIActive(false);
		base.GetButton(5).RootUIComp.Get().SetUIActive(!flag2);
		base.GetButton(8).RootUIComp.Get().SetUIActive(flag2);
	}

	// Token: 0x06010B8E RID: 68494 RVA: 0x00494564 File Offset: 0x00492764
	private void ButtonJumpClick()
	{
		IMotorLevelConditionData data = this.Data;
		bool flag;
		if (data == null)
		{
			flag = false;
		}
		else
		{
			int accessId = data.AccessId;
			flag = true;
		}
		if (!flag || this.Data.AccessId <= 0)
		{
			IMotorLevelConditionData data2 = this.Data;
			bool flag2;
			if (data2 == null)
			{
				flag2 = false;
			}
			else
			{
				int recommendQuestId = data2.RecommendQuestId;
				flag2 = true;
			}
			if (flag2 && this.Data.RecommendQuestId > 0)
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.QuestView, this.Data.RecommendQuestId, null);
				Singleton<UiManager>.Instance.CloseView(EUiViewName.MotorcycleConditionView, null);
			}
			return;
		}
		if (this.Data.AccessType == 3)
		{
			ControllerBase<HelpController>.Instance.OpenHelpById(this.Data.AccessId);
			return;
		}
		SkipTaskManager.RunByConfigId(this.Data.AccessId, null);
		Singleton<UiManager>.Instance.CloseView(EUiViewName.MotorcycleConditionView, null);
	}

	// Token: 0x040083F3 RID: 33779
	[Nullable(2)]
	private IMotorLevelConditionData Data;

	// Token: 0x02008557 RID: 34135
	private class EItemComponents
	{
		// Token: 0x0402D1F1 RID: 184817
		public const int PanelDone = 0;

		// Token: 0x0402D1F2 RID: 184818
		public const int PanelType1 = 1;

		// Token: 0x0402D1F3 RID: 184819
		public const int PanelType2 = 2;

		// Token: 0x0402D1F4 RID: 184820
		public const int SpriteGoing = 3;

		// Token: 0x0402D1F5 RID: 184821
		public const int Txt = 4;

		// Token: 0x0402D1F6 RID: 184822
		public const int ButtonType1 = 5;

		// Token: 0x0402D1F7 RID: 184823
		public const int SpriteDone = 6;

		// Token: 0x0402D1F8 RID: 184824
		public const int TxtGoing = 7;

		// Token: 0x0402D1F9 RID: 184825
		public const int ButtonType2 = 8;
	}
}
