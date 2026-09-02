using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001025 RID: 4133
[NullableContext(1)]
[Nullable(0)]
public class DrinksQTEPanel : UiPanelBase
{
	// Token: 0x06006B7B RID: 27515 RVA: 0x001C21F8 File Offset: 0x001C03F8
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIItem))
		};
	}

	// Token: 0x06006B7C RID: 27516 RVA: 0x001C22AC File Offset: 0x001C04AC
	protected override UniTask OnBeforeStartAsync()
	{
		DrinksQTEPanel.<OnBeforeStartAsync>d__16 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<DrinksQTEPanel.<OnBeforeStartAsync>d__16>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06006B7D RID: 27517 RVA: 0x001C22F0 File Offset: 0x001C04F0
	protected override void OnStart()
	{
		this.MaxTime = (float)ConfigBase<DrinksConfig>.Instance.GetQTETimeLimit();
		this.Speed = (float)ConfigBase<DrinksConfig>.Instance.GetQTESpeed();
		UUIItem item = base.GetItem(6);
		if (item == null)
		{
			return;
		}
		FRotator frotator = this.CurRot.ToUeRotator();
		item.SetUIRelativeRotation(frotator);
	}

	// Token: 0x06006B7E RID: 27518 RVA: 0x001C2340 File Offset: 0x001C0540
	public void StartQTE()
	{
		this.IsFront = true;
		DrinksPlayProxy proxy = ModelBase<DrinksModel>.Instance.GetProxy();
		proxy.HideClose();
		proxy.SetNeedTick(true);
		this.CurRot.Yaw = 45f;
		UUIItem item = base.GetItem(6);
		if (item != null)
		{
			FRotator frotator = this.CurRot.ToUeRotator();
			item.SetUIRelativeRotation(frotator);
		}
		this.CurTime = 0f;
		DrinksQTEButton button = this.Button;
		if (button != null)
		{
			button.SetSelfActive(true);
		}
		DrinksModel instance = ModelBase<DrinksModel>.Instance;
		EDrinksPlayStep curStep = instance.GetCurStep();
		DrinksResultInfo currentPlayData = instance.GetCurrentPlayData();
		int id = (curStep == EDrinksPlayStep.Drink1) ? currentPlayData.DrinkBase[0] : currentPlayData.DrinkBase[1];
		DrinksSoftDrinkData drinksByBaseId = instance.GetDrinksByBaseId(id);
		this.QTEList = drinksByBaseId.GetAllBaseId().ToList<int>();
		this.InitSectionItem();
		UUIItem rootItem = this.RootItem;
		if (rootItem != null)
		{
			rootItem.SetUIActive(true);
		}
		Singleton<EventSystem>.Instance.Emit<string>(EEventName.OnGuideTriggerEvent, "MakeDrinkQTEShow");
	}

	// Token: 0x06006B7F RID: 27519 RVA: 0x001C2430 File Offset: 0x001C0630
	protected void InitSectionItem()
	{
		this.ThreePart1.SetUiActive(this.QTEList.Count == 3);
		this.ThreePart2.SetUiActive(this.QTEList.Count == 3);
		this.ThreePart3.SetUiActive(this.QTEList.Count == 3);
		this.TwoPart1.SetUiActive(this.QTEList.Count == 2);
		this.TwoPart2.SetUiActive(this.QTEList.Count == 2);
		for (int i = 0; i < this.QTEList.Count; i++)
		{
			if (this.QTEList.Count == 3)
			{
				this.ThreePartList[i].ApplyDrinkData(this.QTEList[i]);
			}
			else
			{
				this.TwoPartList[i].ApplyDrinkData(this.QTEList[i]);
			}
		}
	}

	// Token: 0x06006B80 RID: 27520 RVA: 0x001C251C File Offset: 0x001C071C
	protected void UpdateSectionItem()
	{
		int endSection = this.GetEndSection();
		for (int i = 0; i < this.QTEList.Count; i++)
		{
			if (this.QTEList.Count == 3)
			{
				this.ThreePartList[i].SetIsSelected(i == endSection);
			}
			else
			{
				this.TwoPartList[i].SetIsSelected(i == endSection);
			}
		}
	}

	// Token: 0x06006B81 RID: 27521 RVA: 0x001C2580 File Offset: 0x001C0780
	protected void OnProcessEnd()
	{
		int endSection = this.GetEndSection();
		DrinksModel instance = ModelBase<DrinksModel>.Instance;
		if (instance == null)
		{
			return;
		}
		instance.OnDrinkBaseQTEEnd(this.QTEList[endSection]);
	}

	// Token: 0x06006B82 RID: 27522 RVA: 0x001C25B0 File Offset: 0x001C07B0
	protected int GetEndSection()
	{
		float num = this.CurRot.Yaw + 45f;
		float num2 = 90f / (float)this.QTEList.Count;
		int num3 = (int)Math.Max(1.0, Math.Ceiling((double)(num / num2)));
		return this.QTEList.Count - num3;
	}

	// Token: 0x06006B83 RID: 27523 RVA: 0x001C2608 File Offset: 0x001C0808
	public void OnTick(float deltaTime)
	{
		this.CurTime += deltaTime;
		float num = 90f / this.Speed * deltaTime;
		float num2 = this.CurRot.Yaw + num * (float)(this.IsFront ? -1 : 1);
		if (this.IsFront && num2 <= -45f)
		{
			num2 = -45f;
			this.IsFront = false;
		}
		else if (!this.IsFront && num2 >= 45f)
		{
			num2 = 45f;
			this.IsFront = true;
		}
		this.CurRot.Yaw = num2;
		UUIItem item = base.GetItem(6);
		if (item != null)
		{
			FRotator frotator = this.CurRot.ToUeRotator();
			item.SetUIRelativeRotation(frotator);
		}
		this.Button.OnTick(1f - this.CurTime / this.MaxTime);
		if (this.CurTime >= this.MaxTime)
		{
			DrinksQTEButton button = this.Button;
			if (button == null)
			{
				return;
			}
			button.OnClickedBtn();
		}
	}

	// Token: 0x06006B84 RID: 27524 RVA: 0x001C26F2 File Offset: 0x001C08F2
	private void OnClickedCb()
	{
		DrinksQTEButton button = this.Button;
		if (button != null)
		{
			button.SetSelfActive(false);
		}
		this.UpdateSectionItem();
		ModelBase<DrinksModel>.Instance.GetProxy().SetNeedTick(false);
	}

	// Token: 0x06006B85 RID: 27525 RVA: 0x001C271C File Offset: 0x001C091C
	public void OnFadeSequenceEnd()
	{
		this.OnProcessEnd();
		UUIItem rootItem = this.RootItem;
		if (rootItem == null)
		{
			return;
		}
		rootItem.SetUIActive(false);
	}

	// Token: 0x0400330F RID: 13071
	protected float MaxTime = 9f;

	// Token: 0x04003310 RID: 13072
	protected float CurTime;

	// Token: 0x04003311 RID: 13073
	protected float Speed;

	// Token: 0x04003312 RID: 13074
	protected Rotator CurRot = Rotator.Create(0f, 45f, 0f);

	// Token: 0x04003313 RID: 13075
	[Nullable(2)]
	protected DrinksQTEButton Button;

	// Token: 0x04003314 RID: 13076
	protected List<int> QTEList = new List<int>();

	// Token: 0x04003315 RID: 13077
	protected List<DrinksQTESectionItem> ThreePartList = new List<DrinksQTESectionItem>();

	// Token: 0x04003316 RID: 13078
	protected DrinksQTESectionItem ThreePart1;

	// Token: 0x04003317 RID: 13079
	protected DrinksQTESectionItem ThreePart2;

	// Token: 0x04003318 RID: 13080
	protected DrinksQTESectionItem ThreePart3;

	// Token: 0x04003319 RID: 13081
	protected List<DrinksQTESectionItem> TwoPartList = new List<DrinksQTESectionItem>();

	// Token: 0x0400331A RID: 13082
	protected DrinksQTESectionItem TwoPart1;

	// Token: 0x0400331B RID: 13083
	protected DrinksQTESectionItem TwoPart2;

	// Token: 0x0400331C RID: 13084
	protected bool IsFront = true;

	// Token: 0x02007405 RID: 29701
	[NullableContext(0)]
	private static class EItem
	{
		// Token: 0x04028202 RID: 164354
		public const int BtnItem = 0;

		// Token: 0x04028203 RID: 164355
		public const int ThreePartItem1 = 1;

		// Token: 0x04028204 RID: 164356
		public const int ThreePartItem2 = 2;

		// Token: 0x04028205 RID: 164357
		public const int ThreePartItem3 = 3;

		// Token: 0x04028206 RID: 164358
		public const int TwoPartItem1 = 4;

		// Token: 0x04028207 RID: 164359
		public const int TwoPartItem2 = 5;

		// Token: 0x04028208 RID: 164360
		public const int Pointer = 6;
	}
}
