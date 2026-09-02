using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x020060B5 RID: 24757
	[NullableContext(2)]
	[Nullable(0)]
	public class SpecialEnergyBarDaniya : SpecialEnergyBarBase
	{
		// Token: 0x0603E823 RID: 256035 RVA: 0x00FFB238 File Offset: 0x00FF9438
		protected override void OnRegisterComponent()
		{
			Dictionary<int, Type> dictionary = new Dictionary<int, Type>();
			dictionary[1] = typeof(UUISprite);
			dictionary[5] = typeof(UUISprite);
			dictionary[6] = typeof(UUISprite);
			Dictionary<int, Type> dictionary2 = dictionary;
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>(21);
			for (int i = 0; i < 21; i++)
			{
				this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(i, dictionary2.GetValueOrDefault(i, typeof(UUIItem))));
			}
		}

		// Token: 0x0603E824 RID: 256036 RVA: 0x00FFB2BC File Offset: 0x00FF94BC
		protected override UniTask OnBeforeStartAsync()
		{
			SpecialEnergyBarDaniya.<OnBeforeStartAsync>d__19 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<SpecialEnergyBarDaniya.<OnBeforeStartAsync>d__19>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603E825 RID: 256037 RVA: 0x00FFB300 File Offset: 0x00FF9500
		protected UniTask InitBarItem1()
		{
			SpecialEnergyBarDaniya.<InitBarItem1>d__20 <InitBarItem1>d__;
			<InitBarItem1>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitBarItem1>d__.<>4__this = this;
			<InitBarItem1>d__.<>1__state = -1;
			<InitBarItem1>d__.<>t__builder.Start<SpecialEnergyBarDaniya.<InitBarItem1>d__20>(ref <InitBarItem1>d__);
			return <InitBarItem1>d__.<>t__builder.Task;
		}

		// Token: 0x0603E826 RID: 256038 RVA: 0x00FFB344 File Offset: 0x00FF9544
		protected UniTask InitBarItem2()
		{
			SpecialEnergyBarDaniya.<InitBarItem2>d__21 <InitBarItem2>d__;
			<InitBarItem2>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitBarItem2>d__.<>4__this = this;
			<InitBarItem2>d__.<>1__state = -1;
			<InitBarItem2>d__.<>t__builder.Start<SpecialEnergyBarDaniya.<InitBarItem2>d__21>(ref <InitBarItem2>d__);
			return <InitBarItem2>d__.<>t__builder.Task;
		}

		// Token: 0x0603E827 RID: 256039 RVA: 0x00FFB388 File Offset: 0x00FF9588
		[NullableContext(1)]
		private void InitStarItems(List<UUIItem> arr, SpecialEnergyBarDaniya.EChildType org, SpecialEnergyBarDaniya.EChildType perent)
		{
			UUIItem item = base.GetItem((int)org);
			UUIItem item2 = base.GetItem((int)perent);
			arr.Add(item);
			for (int i = 2; i <= 5; i++)
			{
				UUIItem item3 = Singleton<LguiUtil>.Instance.DuplicateActor(item.GetOwner(), item2).GetComponentByClass(UUIItem.StaticClass()) as UUIItem;
				arr.Add(item3);
			}
		}

		// Token: 0x0603E828 RID: 256040 RVA: 0x00FFB3E8 File Offset: 0x00FF95E8
		protected override void OnStart()
		{
			this.InitStarItems(this.StarItemA, SpecialEnergyBarDaniya.EChildType.StarA, SpecialEnergyBarDaniya.EChildType.PnlStarA);
			this.InitStarItems(this.StarItemB, SpecialEnergyBarDaniya.EChildType.StarB, SpecialEnergyBarDaniya.EChildType.PnlStarB);
			for (int i = 17; i <= 20; i++)
			{
				this.StarBgItems.Add(base.GetItem(i));
			}
			for (int j = 9; j <= 12; j++)
			{
				base.InitTweenAnim(j);
			}
			this.BarMidB = base.GetSprite(6);
			this.RefreshState(true);
			if (!this.StarValid || !this.StarFlag)
			{
				this.CurBarSprite.SetFillAmount(0f);
				this.CurBarTips.SetUIActive(false);
			}
			base.PlayTweenAnim((this.CurState == SpecialEnergyBarDaniya.EState.StateA) ? 12 : 10);
		}

		// Token: 0x0603E829 RID: 256041 RVA: 0x00FFB49A File Offset: 0x00FF969A
		protected override void ClearAllTweenAnim()
		{
			BattleUiTweenAnimPlayer tweenAnimPlayer = this.TweenAnimPlayer;
			if (tweenAnimPlayer != null)
			{
				tweenAnimPlayer.Clear(true);
			}
			base.ClearAllTweenAnim();
		}

		// Token: 0x0603E82A RID: 256042 RVA: 0x00FFB4B4 File Offset: 0x00FF96B4
		protected override void AddEvents()
		{
			base.AddEvents();
			base.ListenForTagAddOrRemoveChanged(GameplayTagDefine.EGameplayTagId["角色.R2T1DaniyaMd10011.形态标识.白形态"], new BaseTagComponent.TTagSwitchedCallback(this.OnStyleChanged));
			base.ListenForTagAddOrRemoveChanged(GameplayTagDefine.EGameplayTagId["角色.R2T1DaniyaMd10011.形态标识.黑形态"], new BaseTagComponent.TTagSwitchedCallback(this.OnStyleChanged));
			base.ListenForTagAddOrRemoveChanged(GameplayTagDefine.EGameplayTagId["角色.R2T1DaniyaMd10011.UI标识.能量条一转二"], new BaseTagComponent.TTagSwitchedCallback(this.OnPlayAnim));
			base.ListenForTagAddOrRemoveChanged(GameplayTagDefine.EGameplayTagId["角色.R2T1DaniyaMd10011.UI标识.能量条二转一"], new BaseTagComponent.TTagSwitchedCallback(this.OnPlayAnim));
			base.ListenForTagAddOrRemoveChanged(GameplayTagDefine.EGameplayTagId["角色.R2T1DaniyaMd10011.共鸣链.3共"], new BaseTagComponent.TTagSwitchedCallback(this.OnUpdateBuffId));
			this.UpdateBuffId();
			base.ListenForTagAddOrRemoveChanged(GameplayTagDefine.EGameplayTagId["角色.R2T1DaniyaMd10011.buff标识.无穷集"], new BaseTagComponent.TTagSwitchedCallback(this.OnStarStateChanged));
			base.ListenForTagAddOrRemoveChanged(GameplayTagDefine.EGameplayTagId["角色.R2T1DaniyaMd10011.buff标识.容器"], new BaseTagComponent.TTagSwitchedCallback(this.OnStarStateChanged));
			this.AttributeComponent.AddListener(EAttributeType.SpecialEnergy2, new Action<EAttributeType, float, float>(this.OnStarChanged), null);
			this.AttributeComponent.AddListener(EAttributeType.SpecialEnergy3, new Action<EAttributeType, float, float>(this.OnR2Changed), null);
		}

		// Token: 0x0603E82B RID: 256043 RVA: 0x00FFB5E8 File Offset: 0x00FF97E8
		private void UpdateBuffId()
		{
			long curBuffId = this.CurBuffId;
			this.CurBuffId = (this.TagComponent.HasTag(GameplayTagDefine.EGameplayTagId["角色.R2T1DaniyaMd10011.共鸣链.3共"]) ? 1211300002L : 1211300001L);
			if (curBuffId != this.CurBuffId)
			{
				bool flag = this.CurBuffId == 1211300002L;
				SpecialEnergyBarDaniya.<UpdateBuffId>g__updateBg|27_0(this.StarItemA, flag ? 5 : 3);
				SpecialEnergyBarDaniya.<UpdateBuffId>g__updateBg|27_0(this.StarItemB, flag ? 5 : 3);
				foreach (UUIItem uuiitem in this.StarBgItems)
				{
					uuiitem.SetUIActive(flag);
				}
				this.RefreshStarItems(this.AttributeComponent.GetCurrentValue(EAttributeType.SpecialEnergy2));
			}
			BattleUiRoleData roleData = this.RoleData;
			WorldEntity worldEntity;
			if (roleData == null)
			{
				worldEntity = null;
			}
			else
			{
				EntityHandle entityHandle = roleData.EntityHandle;
				worldEntity = ((entityHandle != null) ? entityHandle.Entity : null);
			}
			WorldEntity worldEntity2 = worldEntity;
			if (worldEntity2 != null)
			{
				if (curBuffId != 0L)
				{
					AbilityEvent.Instance.Remove(worldEntity2, EAbilityEventName.OnBuffAdd, this.CurBuffId, new Action<long, int>(this.OnStarBuffAdd));
				}
				AbilityEvent.Instance.Add(worldEntity2, EAbilityEventName.OnBuffAdd, this.CurBuffId, new Action<long, int>(this.OnStarBuffAdd));
			}
			this.StarBuff = null;
			this.RefreshStarState(false);
		}

		// Token: 0x0603E82C RID: 256044 RVA: 0x00FFB730 File Offset: 0x00FF9930
		private void OnStyleChanged(int tagId, bool tagExist)
		{
			this.RefreshState(false);
		}

		// Token: 0x0603E82D RID: 256045 RVA: 0x00FFB73C File Offset: 0x00FF993C
		private void OnPlayAnim(int tagId, bool tagExist)
		{
			if (tagExist)
			{
				SpecialEnergyBarDaniya.EChildType componentType = (tagId == GameplayTagDefine.EGameplayTagId["角色.R2T1DaniyaMd10011.UI标识.能量条一转二"]) ? SpecialEnergyBarDaniya.EChildType.AniToB : SpecialEnergyBarDaniya.EChildType.AniToA;
				base.PlayTweenAnim((int)componentType);
			}
		}

		// Token: 0x0603E82E RID: 256046 RVA: 0x00FFB76C File Offset: 0x00FF996C
		private void OnStarChanged(EAttributeType attrId, float newValue, float oldValue)
		{
			this.RefreshStarItems(newValue);
		}

		// Token: 0x0603E82F RID: 256047 RVA: 0x00FFB775 File Offset: 0x00FF9975
		private void OnUpdateBuffId(int tagId, bool tagExist)
		{
			this.UpdateBuffId();
		}

		// Token: 0x0603E830 RID: 256048 RVA: 0x00FFB77D File Offset: 0x00FF997D
		private void OnR2Changed(EAttributeType attrId, float newValue, float oldValue)
		{
			this.RefreshR2(newValue);
		}

		// Token: 0x0603E831 RID: 256049 RVA: 0x00FFB786 File Offset: 0x00FF9986
		private void OnStarStateChanged(int tagId, bool tagExist)
		{
			this.RefreshStarState(false);
		}

		// Token: 0x0603E832 RID: 256050 RVA: 0x00FFB790 File Offset: 0x00FF9990
		private void RefreshStarItems(float count)
		{
			List<UUIItem> list = (this.CurState == SpecialEnergyBarDaniya.EState.StateA) ? this.StarItemA : this.StarItemB;
			for (int i = 0; i < list.Count; i++)
			{
				UUIItem uuiitem = list[i];
				if ((float)i < count)
				{
					if (!uuiitem.IsUIActiveSelf())
					{
						uuiitem.SetUIActive(true);
					}
				}
				else
				{
					uuiitem.SetUIActive(false);
				}
			}
		}

		// Token: 0x0603E833 RID: 256051 RVA: 0x00FFB7EC File Offset: 0x00FF99EC
		private void RefreshR2(float cur)
		{
			float currentValue = this.AttributeComponent.GetCurrentValue(EAttributeType.SpecialEnergy3Max);
			float num = cur / currentValue;
			this.BarMidB.SetFillAmount(num);
			if (num >= 1f && this.LastR2Percent < 1f)
			{
				base.PlayTweenAnim(11);
			}
			this.LastR2Percent = num;
		}

		// Token: 0x0603E834 RID: 256052 RVA: 0x00FFB83C File Offset: 0x00FF9A3C
		protected override void OnBarPercentChanged()
		{
			float curPercent = this.PercentMachine.GetCurPercent();
			if (this.CurState == SpecialEnergyBarDaniya.EState.StateA)
			{
				if (curPercent >= 1f && this.LastPercentA < 1f)
				{
					base.PlayTweenAnim(9);
				}
				this.BarSlotA.RefreshSlotKeyEnable(curPercent > 0f, false);
				this.LastPercentA = curPercent;
				return;
			}
			this.BarSlotB.RefreshSlotKeyEnable(curPercent > 0f, false);
		}

		// Token: 0x0603E835 RID: 256053 RVA: 0x00FFB8AA File Offset: 0x00FF9AAA
		private void RefreshState(bool isStart = false)
		{
			if (this.TagComponent.HasTag(GameplayTagDefine.EGameplayTagId["角色.R2T1DaniyaMd10011.形态标识.白形态"]))
			{
				this.SetState(SpecialEnergyBarDaniya.EState.StateA, isStart);
				return;
			}
			this.SetState(SpecialEnergyBarDaniya.EState.StateB, isStart);
		}

		// Token: 0x0603E836 RID: 256054 RVA: 0x00FFB8DC File Offset: 0x00FF9ADC
		private void SetState(SpecialEnergyBarDaniya.EState state, bool isStart = false)
		{
			if (state == this.CurState && !isStart)
			{
				return;
			}
			if (this.CurState != state)
			{
				BattleUiTweenAnimPlayer tweenAnimPlayer = this.TweenAnimPlayer;
				if (tweenAnimPlayer != null)
				{
					tweenAnimPlayer.StopAll();
				}
				base.PlayTweenAnim((state == SpecialEnergyBarDaniya.EState.StateA) ? 12 : 10);
			}
			this.CurState = state;
			this.CurBarSprite = base.GetSprite((state == SpecialEnergyBarDaniya.EState.StateA) ? 1 : 5);
			this.CurBarTips = base.GetItem((state == SpecialEnergyBarDaniya.EState.StateA) ? 14 : 16);
			UUIItem item = base.GetItem((state == SpecialEnergyBarDaniya.EState.StateA) ? 13 : 15);
			this.BarTipsWidth = item.GetParentAsUIItem().Width;
			this.RefreshStarState(false);
			this.RefreshStarItems(this.AttributeComponent.GetCurrentValue(EAttributeType.SpecialEnergy2));
			float curPercent = this.PercentMachine.GetCurPercent();
			if (state == SpecialEnergyBarDaniya.EState.StateA)
			{
				this.BarSlotA.RefreshSlotKeyEnable(curPercent > 0f, true);
				return;
			}
			this.BarSlotB.RefreshSlotKeyEnable(curPercent > 0f, true);
			this.RefreshR2(this.AttributeComponent.GetCurrentValue(EAttributeType.SpecialEnergy3));
		}

		// Token: 0x0603E837 RID: 256055 RVA: 0x00FFB9D4 File Offset: 0x00FF9BD4
		private void RefreshStarState(bool isStart = false)
		{
			this.StarValid = (this.TagComponent.HasTag(GameplayTagDefine.EGameplayTagId["角色.R2T1DaniyaMd10011.buff标识.无穷集"]) || this.TagComponent.HasTag(GameplayTagDefine.EGameplayTagId["角色.R2T1DaniyaMd10011.buff标识.容器"]));
			if (!this.StarValid)
			{
				CharacterBuffComponent buffComponent = this.BuffComponent;
				this.StarBuff = ((buffComponent != null) ? buffComponent.GetBuffById(this.CurBuffId) : null);
				if (this.StarBuff != null && this.StarBuff.IsValid())
				{
					this.StarValid = true;
				}
			}
			if (this.StarValid)
			{
				this.TickStarProgress();
			}
		}

		// Token: 0x0603E838 RID: 256056 RVA: 0x00FFBA70 File Offset: 0x00FF9C70
		private void OnStarBuffAdd(long buffId, int handle)
		{
			this.RefreshStarState(false);
		}

		// Token: 0x0603E839 RID: 256057 RVA: 0x00FFBA7C File Offset: 0x00FF9C7C
		private void TickStarProgress()
		{
			if (!this.StarValid)
			{
				return;
			}
			if (this.StarBuff == null || !this.StarBuff.IsValid())
			{
				CharacterBuffComponent buffComponent = this.BuffComponent;
				this.StarBuff = ((buffComponent != null) ? buffComponent.GetBuffById(this.CurBuffId) : null);
			}
			if (this.StarBuff != null && this.StarBuff.IsActive())
			{
				float valueOrDefault = this.StarBuff.GetRemainPeriod().GetValueOrDefault();
				float num = 1f - ((valueOrDefault < 0f) ? 0f : ((float)Singleton<MathUtils>.Instance.SafeDivide((double)valueOrDefault, (double)this.StarBuff.Period)));
				this.CurBarSprite.SetFillAmount(num);
				if (this.CurBarTips.IsUIActiveSelf())
				{
					this.CurBarTips.SetAnchorOffsetX(this.BarTipsWidth * num);
					if (num <= 0f)
					{
						this.CurBarTips.SetUIActive(false);
					}
				}
				else if (num > 0f)
				{
					this.CurBarTips.SetUIActive(true);
				}
				this.StarFlag = true;
				return;
			}
			if (this.StarFlag)
			{
				this.StarFlag = false;
				this.CurBarSprite.SetFillAmount(0f);
				this.CurBarTips.SetUIActive(false);
			}
		}

		// Token: 0x0603E83A RID: 256058 RVA: 0x00FFBBAC File Offset: 0x00FF9DAC
		public override void Tick(float delta)
		{
			base.Tick(delta);
			SpecialEnergyBarDaniyaSlot barSlotA = this.BarSlotA;
			if (barSlotA != null)
			{
				barSlotA.Tick(delta);
			}
			SpecialEnergyBarDaniyaSlot barSlotB = this.BarSlotB;
			if (barSlotB != null)
			{
				barSlotB.Tick(delta);
			}
			this.TickStarProgress();
		}

		// Token: 0x0603E83B RID: 256059 RVA: 0x00FFBBE0 File Offset: 0x00FF9DE0
		protected override void OnBeforeDestroy()
		{
			this.StarItemA.Clear();
			this.StarItemB.Clear();
			BattleUiRoleData roleData = this.RoleData;
			WorldEntity worldEntity;
			if (roleData == null)
			{
				worldEntity = null;
			}
			else
			{
				EntityHandle entityHandle = roleData.EntityHandle;
				worldEntity = ((entityHandle != null) ? entityHandle.Entity : null);
			}
			WorldEntity worldEntity2 = worldEntity;
			if (worldEntity2 != null)
			{
				AbilityEvent.Instance.Remove(worldEntity2, EAbilityEventName.OnBuffAdd, this.CurBuffId, new Action<long, int>(this.OnStarBuffAdd));
			}
			base.OnBeforeDestroy();
		}

		// Token: 0x0603E83D RID: 256061 RVA: 0x00FFBC80 File Offset: 0x00FF9E80
		[NullableContext(1)]
		[CompilerGenerated]
		internal static void <UpdateBuffId>g__updateBg|27_0(List<UUIItem> items, int num)
		{
			for (int i = 0; i < items.Count; i++)
			{
				items[i].SetUIActive(i < num);
			}
		}

		// Token: 0x04023099 RID: 143513
		private const int CONFIG_INFO_B = 121102;

		// Token: 0x0402309A RID: 143514
		private const long PCT_STAR_BAR_BUFFID1 = 1211300001L;

		// Token: 0x0402309B RID: 143515
		private const long PCT_STAR_BAR_BUFFID2 = 1211300002L;

		// Token: 0x0402309C RID: 143516
		private const EAttributeType ENERGY_STAR = EAttributeType.SpecialEnergy2;

		// Token: 0x0402309D RID: 143517
		private const EAttributeType ENERGY_R2 = EAttributeType.SpecialEnergy3;

		// Token: 0x0402309E RID: 143518
		private const EAttributeType ENERGY_R2_MAX = EAttributeType.SpecialEnergy3Max;

		// Token: 0x0402309F RID: 143519
		private SpecialEnergyBarDaniyaSlot BarSlotA;

		// Token: 0x040230A0 RID: 143520
		private SpecialEnergyBarDaniyaSlot BarSlotB;

		// Token: 0x040230A1 RID: 143521
		private SpecialEnergyBarDaniya.EState CurState;

		// Token: 0x040230A2 RID: 143522
		[Nullable(1)]
		private readonly List<UUIItem> StarItemA = new List<UUIItem>();

		// Token: 0x040230A3 RID: 143523
		[Nullable(1)]
		private readonly List<UUIItem> StarItemB = new List<UUIItem>();

		// Token: 0x040230A4 RID: 143524
		[Nullable(1)]
		private readonly List<UUIItem> StarBgItems = new List<UUIItem>();

		// Token: 0x040230A5 RID: 143525
		private UUISprite BarMidB;

		// Token: 0x040230A6 RID: 143526
		private UUISprite CurBarSprite;

		// Token: 0x040230A7 RID: 143527
		private UUIItem CurBarTips;

		// Token: 0x040230A8 RID: 143528
		private float BarTipsWidth = 1f;

		// Token: 0x040230A9 RID: 143529
		private long CurBuffId;

		// Token: 0x040230AA RID: 143530
		private float LastR2Percent;

		// Token: 0x040230AB RID: 143531
		private float LastPercentA;

		// Token: 0x040230AC RID: 143532
		private bool StarValid;

		// Token: 0x040230AD RID: 143533
		private ActiveBuffInternal StarBuff;

		// Token: 0x040230AE RID: 143534
		private bool StarFlag;

		// Token: 0x0200C1D8 RID: 49624
		[NullableContext(0)]
		private enum EChildType
		{
			// Token: 0x0403BB20 RID: 244512
			SlotA,
			// Token: 0x0403BB21 RID: 244513
			BarA,
			// Token: 0x0403BB22 RID: 244514
			PnlStarA,
			// Token: 0x0403BB23 RID: 244515
			StarA,
			// Token: 0x0403BB24 RID: 244516
			SlotB,
			// Token: 0x0403BB25 RID: 244517
			BarB,
			// Token: 0x0403BB26 RID: 244518
			BarMidB,
			// Token: 0x0403BB27 RID: 244519
			PnlStarB,
			// Token: 0x0403BB28 RID: 244520
			StarB,
			// Token: 0x0403BB29 RID: 244521
			AniToAFull,
			// Token: 0x0403BB2A RID: 244522
			AniToB,
			// Token: 0x0403BB2B RID: 244523
			AniToBFull,
			// Token: 0x0403BB2C RID: 244524
			AniToA,
			// Token: 0x0403BB2D RID: 244525
			PnlWidthA,
			// Token: 0x0403BB2E RID: 244526
			PnlNiaA,
			// Token: 0x0403BB2F RID: 244527
			PnlWidthB,
			// Token: 0x0403BB30 RID: 244528
			PnlNiaB,
			// Token: 0x0403BB31 RID: 244529
			StarBgA1,
			// Token: 0x0403BB32 RID: 244530
			StarBgA2,
			// Token: 0x0403BB33 RID: 244531
			StarBgB1,
			// Token: 0x0403BB34 RID: 244532
			StarBgB2,
			// Token: 0x0403BB35 RID: 244533
			MaxCount
		}

		// Token: 0x0200C1D9 RID: 49625
		[NullableContext(0)]
		private enum EState
		{
			// Token: 0x0403BB37 RID: 244535
			StateA,
			// Token: 0x0403BB38 RID: 244536
			StateB
		}
	}
}
