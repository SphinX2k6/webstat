using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020015F3 RID: 5619
[NullableContext(1)]
[Nullable(0)]
public class ActivityTurntableQuestItem : UiPanelBase
{
	// Token: 0x06009E61 RID: 40545 RVA: 0x00297380 File Offset: 0x00295580
	protected unsafe override void OnRegisterComponent()
	{
		int num = 5;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnClickedQuestJump));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06009E62 RID: 40546 RVA: 0x0029748C File Offset: 0x0029568C
	protected override UniTask OnBeforeStartAsync()
	{
		ActivityTurntableQuestItem.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ActivityTurntableQuestItem.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06009E63 RID: 40547 RVA: 0x002974D0 File Offset: 0x002956D0
	public void Refresh(bool isFinished, TItem reward, int questId, int activityId)
	{
		ItemGridData data = new ItemGridData
		{
			Item = reward,
			HasClaimed = isFinished
		};
		this.RewardItemGrid.Refresh(data);
		base.GetButton(3).RootUIComp.Get().SetUIActive(!isFinished);
		this.QuestId = questId;
		this.ActivityId = activityId;
	}

	// Token: 0x06009E64 RID: 40548 RVA: 0x00297529 File Offset: 0x00295729
	public void SetTitle(string textId, params string[] args)
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), textId, args);
	}

	// Token: 0x06009E65 RID: 40549 RVA: 0x0029753E File Offset: 0x0029573E
	public void SetTxtById(string textId, params string[] args)
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), textId, args);
	}

	// Token: 0x06009E66 RID: 40550 RVA: 0x00297553 File Offset: 0x00295753
	public void SetTxt(string text)
	{
		base.GetText(1).SetText(text, true);
	}

	// Token: 0x06009E67 RID: 40551 RVA: 0x00297563 File Offset: 0x00295763
	public void SetRedDot(bool bVisible)
	{
		base.GetItem(4).SetUIActive(bVisible);
	}

	// Token: 0x06009E68 RID: 40552 RVA: 0x00297572 File Offset: 0x00295772
	private void OnClickedQuestJump()
	{
		if (this.QuestId != 0)
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.QuestView, this.QuestId, null);
			ActivityTurntableData turntableData = this.GetTurntableData();
			if (turntableData == null)
			{
				return;
			}
			turntableData.ReadCurrentUnlockQuest();
		}
	}

	// Token: 0x06009E69 RID: 40553 RVA: 0x002975A7 File Offset: 0x002957A7
	[NullableContext(2)]
	private ActivityTurntableData GetTurntableData()
	{
		if (this.ActivityId != 0)
		{
			return ModelBase<ActivityModel>.Instance.GetActivityById(this.ActivityId) as ActivityTurntableData;
		}
		return null;
	}

	// Token: 0x040048DB RID: 18651
	private int QuestId;

	// Token: 0x040048DC RID: 18652
	private int ActivityId;

	// Token: 0x040048DD RID: 18653
	[Nullable(2)]
	private ActivitySmallItemGrid RewardItemGrid;

	// Token: 0x020079B2 RID: 31154
	[NullableContext(0)]
	private class EQuestComponents
	{
		// Token: 0x04029CA9 RID: 171177
		public const int Title = 0;

		// Token: 0x04029CAA RID: 171178
		public const int Txt = 1;

		// Token: 0x04029CAB RID: 171179
		public const int ItemGrid = 2;

		// Token: 0x04029CAC RID: 171180
		public const int Button = 3;

		// Token: 0x04029CAD RID: 171181
		public const int RedDot = 4;
	}
}
