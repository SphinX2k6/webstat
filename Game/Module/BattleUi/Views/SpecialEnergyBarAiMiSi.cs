using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Protocol;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x020060AA RID: 24746
	[NullableContext(2)]
	[Nullable(0)]
	public class SpecialEnergyBarAiMiSi : SpecialEnergyBarBase
	{
		// Token: 0x0603E79A RID: 255898 RVA: 0x00FF7D3C File Offset: 0x00FF5F3C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 26;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(17, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(18, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(19, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(20, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(21, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(22, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(23, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(24, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(25, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603E79B RID: 255899 RVA: 0x00FF80CF File Offset: 0x00FF62CF
		protected override void OnInitData()
		{
			this.SubConfig = ModelBase<BattleUiModel>.Instance.SpecialEnergyBarData.GetSpecialEnergyBarInfo(121001);
			this.MaxAttributeId = (EAttributeType)this.SubConfig.MaxAttributeId;
			this.AttributeId = (EAttributeType)this.SubConfig.AttributeId;
		}

		// Token: 0x0603E79C RID: 255900 RVA: 0x00FF8110 File Offset: 0x00FF6310
		protected override void AddEvents()
		{
			base.AddEvents();
			base.ListenForTagAddOrRemoveChanged(this.SubConfig.KeyEnableTagId, new BaseTagComponent.TTagSwitchedCallback(this.OnSubTagChange));
			base.ListenForTagAddOrRemoveChanged(SpecialEnergyBarAiMiSi.modeTag, new BaseTagComponent.TTagSwitchedCallback(this.OnModeTagChange));
			base.ListenForTagAddOrRemoveChanged(SpecialEnergyBarAiMiSi.burstTag, new BaseTagComponent.TTagSwitchedCallback(this.OnBurstTagChange));
		}

		// Token: 0x0603E79D RID: 255901 RVA: 0x00FF816E File Offset: 0x00FF636E
		private void OnSubTagChange(int tagId, bool tagExist)
		{
			this.ShowSubBar = tagExist;
			this.RefreshSubBar();
		}

		// Token: 0x0603E79E RID: 255902 RVA: 0x00FF817D File Offset: 0x00FF637D
		private void OnModeTagChange(int tagId, bool tagExist)
		{
			this.ModeOneTag = tagExist;
			this.RefreshEffectColor();
		}

		// Token: 0x0603E79F RID: 255903 RVA: 0x00FF818C File Offset: 0x00FF638C
		private void OnBurstTagChange(int tagId, bool tagExist)
		{
			if (this.BurstTag == tagExist)
			{
				return;
			}
			this.BurstTag = tagExist;
			this.RefreshBurstState();
		}

		// Token: 0x0603E7A0 RID: 255904 RVA: 0x00FF81A8 File Offset: 0x00FF63A8
		protected override UniTask OnBeforeStartAsync()
		{
			SpecialEnergyBarAiMiSi.<OnBeforeStartAsync>d__26 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<SpecialEnergyBarAiMiSi.<OnBeforeStartAsync>d__26>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603E7A1 RID: 255905 RVA: 0x00FF81EC File Offset: 0x00FF63EC
		protected UniTask InitBarItem()
		{
			SpecialEnergyBarAiMiSi.<InitBarItem>d__27 <InitBarItem>d__;
			<InitBarItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitBarItem>d__.<>4__this = this;
			<InitBarItem>d__.<>1__state = -1;
			<InitBarItem>d__.<>t__builder.Start<SpecialEnergyBarAiMiSi.<InitBarItem>d__27>(ref <InitBarItem>d__);
			return <InitBarItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603E7A2 RID: 255906 RVA: 0x00FF8230 File Offset: 0x00FF6430
		[NullableContext(1)]
		protected override UniTask InitKeyItem(UUIItem keyItemContainer)
		{
			SpecialEnergyBarAiMiSi.<InitKeyItem>d__28 <InitKeyItem>d__;
			<InitKeyItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitKeyItem>d__.<>4__this = this;
			<InitKeyItem>d__.keyItemContainer = keyItemContainer;
			<InitKeyItem>d__.<>1__state = -1;
			<InitKeyItem>d__.<>t__builder.Start<SpecialEnergyBarAiMiSi.<InitKeyItem>d__28>(ref <InitKeyItem>d__);
			return <InitKeyItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603E7A3 RID: 255907 RVA: 0x00FF827C File Offset: 0x00FF647C
		protected override void OnStart()
		{
			for (SpecialEnergyBarAiMiSi.EChildType echildType = SpecialEnergyBarAiMiSi.EChildType.AniDefault; echildType <= SpecialEnergyBarAiMiSi.EChildType.AniStarReset; echildType++)
			{
				base.InitTweenAnim((int)echildType);
			}
			this.TexStarBgList.Clear();
			this.StarItemList.Clear();
			for (int i = 0; i < 4; i++)
			{
				this.TexStarBgList.Add(base.GetTexture(17 + i));
				this.StarItemList.Add(base.GetItem(21 + i));
			}
			base.PlayTweenAnim(4);
			this.TexProgress = base.GetTexture(3);
			this.RefreshState(true);
			this.RefreshBuffPercent(true);
			this.RefreshStar(true);
		}

		// Token: 0x0603E7A4 RID: 255908 RVA: 0x00FF8312 File Offset: 0x00FF6512
		protected override void OnBeforeDestroy()
		{
			this.StopDelayResetStar();
			base.OnBeforeDestroy();
		}

		// Token: 0x0603E7A5 RID: 255909 RVA: 0x00FF8320 File Offset: 0x00FF6520
		protected override void ClearAllTweenAnim()
		{
			base.StopTweenAnim(13);
			base.ClearAllTweenAnim();
		}

		// Token: 0x0603E7A6 RID: 255910 RVA: 0x00FF8330 File Offset: 0x00FF6530
		private void RefreshBuffPercent(bool isStart = false)
		{
			if (this.TexProgress == null)
			{
				return;
			}
			float num = 0f;
			bool bPlay = false;
			if (this.ShowSubBar)
			{
				if (this.Buff != null)
				{
					CharacterBuffComponent buffComponent = this.BuffComponent;
					if (((buffComponent != null) ? buffComponent.GetBuffByHandle(this.BuffHandle) : null) != null)
					{
						goto IL_41;
					}
				}
				this.RefreshBuff();
				IL_41:
				if (this.Buff != null)
				{
					num = this.Buff.GetRemainDuration() / this.Buff.Duration;
					bPlay = (this.Buff.GetRemainDuration() < this.SubConfig.ExtraFloatParams[0]);
				}
			}
			this.PlayWarnAnim(bPlay);
			if (num == this.SubBarPercent && !isStart)
			{
				return;
			}
			this.SubBarPercent = num;
			this.TexProgress.SetFillAmount(num);
		}

		// Token: 0x0603E7A7 RID: 255911 RVA: 0x00FF83E4 File Offset: 0x00FF65E4
		private void PlayWarnAnim(bool bPlay)
		{
			if (this.IsPlayWarnAnim == bPlay)
			{
				return;
			}
			this.IsPlayWarnAnim = bPlay;
			if (bPlay)
			{
				base.PlayTweenAnim(13);
				return;
			}
			base.StopTweenAnim(13);
			base.PlayTweenAnim(14);
		}

		// Token: 0x0603E7A8 RID: 255912 RVA: 0x00FF8414 File Offset: 0x00FF6614
		private void RefreshState(bool isStart = false)
		{
			BaseTagComponent tagComponent = this.TagComponent;
			this.ShowSubBar = (tagComponent != null && tagComponent.HasTag(this.SubConfig.KeyEnableTagId));
			BaseTagComponent tagComponent2 = this.TagComponent;
			this.ModeOneTag = (tagComponent2 != null && tagComponent2.HasTag(SpecialEnergyBarAiMiSi.modeTag));
			BaseTagComponent tagComponent3 = this.TagComponent;
			this.BurstTag = (tagComponent3 != null && tagComponent3.HasTag(SpecialEnergyBarAiMiSi.burstTag));
			this.RefreshSubBar();
			this.RefreshEffectColor();
			this.RefreshBurstState();
		}

		// Token: 0x0603E7A9 RID: 255913 RVA: 0x00FF8490 File Offset: 0x00FF6690
		private void RefreshSubBar()
		{
			this.Buff = null;
			if (this.ShowSubBar)
			{
				base.StopTweenAnim(12);
				base.StopTweenAnim(15);
				base.PlayTweenAnim(11);
				return;
			}
			base.StopTweenAnim(11);
			if (this.IsPlayBurstAnim)
			{
				this.IsPlayBurstAnim = false;
				base.StopTweenAnim(10);
				base.PlayTweenAnim(15);
				base.PlayTweenAnim(12);
				return;
			}
			base.PlayTweenAnim(12);
		}

		// Token: 0x0603E7AA RID: 255914 RVA: 0x00FF84FD File Offset: 0x00FF66FD
		private void RefreshEffectColor()
		{
			SpecialEnergyBarAiMiSiSlot barItemNormal = this.BarItemNormal;
			if (barItemNormal == null)
			{
				return;
			}
			barItemNormal.SetBarColor((!this.ModeOneTag) ? 1 : 0);
		}

		// Token: 0x0603E7AB RID: 255915 RVA: 0x00FF8518 File Offset: 0x00FF6718
		private void RefreshBurstState()
		{
			if (this.BurstTag)
			{
				this.IsPlayBurstAnim = true;
				base.PlayTweenAnim(10);
			}
			UUIItem item = base.GetItem(25);
			if (item != null)
			{
				item.SetUIActive(this.BurstTag);
			}
			SpecialEnergyBarAiMiSiSlot barItemNormal = this.BarItemNormal;
			if (barItemNormal == null)
			{
				return;
			}
			barItemNormal.SetKeyVisible(!this.BurstTag);
		}

		// Token: 0x0603E7AC RID: 255916 RVA: 0x00FF8570 File Offset: 0x00FF6770
		private void RefreshStar(bool isStart = false)
		{
			int num = (int)MathF.Round(this.PercentMachine.GetTargetPercent() * 4f);
			if (this.StarNum == num && !isStart)
			{
				return;
			}
			if (num <= 0)
			{
				if (isStart)
				{
					this.ResetStarImmediately();
				}
				else
				{
					if (this.StarNum >= 4 && this.IsPlayBurstAnim)
					{
						base.PlayTweenAnim(5);
					}
					else
					{
						base.PlayTweenAnim(16);
					}
					this.IsPlayAniStarReset = true;
					this.DelayResetStar();
				}
			}
			else if (num > this.StarNum)
			{
				if (this.IsPlayAniStarReset)
				{
					this.IsPlayAniStarReset = false;
					base.StopTweenAnim(16);
				}
				if (this.StarNum <= 0)
				{
					this.ResetStarImmediately();
				}
				for (int i = this.StarNum; i < num; i++)
				{
					base.PlayTweenAnim(6 + i);
				}
			}
			else
			{
				this.ResetStarImmediately();
				for (int j = 0; j < num; j++)
				{
					base.PlayTweenAnim(6 + j);
				}
			}
			this.StarNum = num;
		}

		// Token: 0x0603E7AD RID: 255917 RVA: 0x00FF8652 File Offset: 0x00FF6852
		private void DelayResetStar()
		{
			this.StopDelayResetStar();
			this.DelayResetStarTimer = TimerSystem.Instance.Delay(delegate(float _)
			{
				this.ResetStar();
				this.DelayResetStarTimer = null;
			}, 250f, null, null, true, 1f);
		}

		// Token: 0x0603E7AE RID: 255918 RVA: 0x00FF8683 File Offset: 0x00FF6883
		private void StopDelayResetStar()
		{
			if (this.DelayResetStarTimer != null)
			{
				if (TimerSystem.Instance.Has(this.DelayResetStarTimer))
				{
					TimerSystem.Instance.Remove(this.DelayResetStarTimer);
				}
				this.DelayResetStarTimer = null;
			}
		}

		// Token: 0x0603E7AF RID: 255919 RVA: 0x00FF86B7 File Offset: 0x00FF68B7
		private void ResetStarImmediately()
		{
			this.StopDelayResetStar();
			this.ResetStar();
		}

		// Token: 0x0603E7B0 RID: 255920 RVA: 0x00FF86C8 File Offset: 0x00FF68C8
		private void ResetStar()
		{
			foreach (UUIItem uuiitem in this.StarItemList)
			{
				uuiitem.SetUIActive(false);
			}
			foreach (UUITexture uuitexture in this.TexStarBgList)
			{
				uuitexture.SetAlpha(1f);
			}
		}

		// Token: 0x0603E7B1 RID: 255921 RVA: 0x00FF8760 File Offset: 0x00FF6960
		protected override void OnBarPercentChanged()
		{
			this.RefreshStar(false);
		}

		// Token: 0x0603E7B2 RID: 255922 RVA: 0x00FF8769 File Offset: 0x00FF6969
		public override void Tick(float delta)
		{
			base.Tick(delta);
			SpecialEnergyBarAiMiSiSlot barItemNormal = this.BarItemNormal;
			if (barItemNormal != null)
			{
				barItemNormal.Tick(delta);
			}
			this.RefreshBuffPercent(false);
		}

		// Token: 0x0603E7B3 RID: 255923 RVA: 0x00FF878C File Offset: 0x00FF698C
		private void RefreshBuff()
		{
			SpecialEnergyBarInfo subConfig = this.SubConfig;
			bool flag;
			if (subConfig == null)
			{
				flag = false;
			}
			else
			{
				long buffId = subConfig.BuffId;
				flag = true;
			}
			if (flag)
			{
				if (this.Buff == null)
				{
					CharacterBuffComponent buffComponent = this.BuffComponent;
					this.Buff = ((buffComponent != null) ? buffComponent.GetBuffById(this.SubConfig.BuffId) : null);
				}
				IActiveBuff buff = this.Buff;
				this.BuffHandle = ((buff != null) ? buff.Handle : 0);
				return;
			}
			this.Buff = null;
			this.BuffHandle = 0;
		}

		// Token: 0x0402304C RID: 143436
		private const int SUB_CONFIG_ID = 121001;

		// Token: 0x0402304D RID: 143437
		[StaticVariableRuleIgnore]
		private static readonly int modeTag = GameplayTagDefine.EGameplayTagId["角色.Common.双模式.模式1"];

		// Token: 0x0402304E RID: 143438
		[StaticVariableRuleIgnore]
		private static readonly int burstTag = GameplayTagDefine.EGameplayTagId["角色.AimisiMd10011.状态.炮大招激活"];

		// Token: 0x0402304F RID: 143439
		private SpecialEnergyBarInfo SubConfig;

		// Token: 0x04023050 RID: 143440
		private SpecialEnergyBarAiMiSiSlot BarItemNormal;

		// Token: 0x04023051 RID: 143441
		private IActiveBuff Buff;

		// Token: 0x04023052 RID: 143442
		private int BuffHandle;

		// Token: 0x04023053 RID: 143443
		private bool ShowSubBar;

		// Token: 0x04023054 RID: 143444
		private float SubBarPercent = -1f;

		// Token: 0x04023055 RID: 143445
		private UUITexture TexProgress;

		// Token: 0x04023056 RID: 143446
		private bool IsPlayWarnAnim;

		// Token: 0x04023057 RID: 143447
		private int StarNum;

		// Token: 0x04023058 RID: 143448
		private bool ModeOneTag;

		// Token: 0x04023059 RID: 143449
		private bool BurstTag;

		// Token: 0x0402305A RID: 143450
		private bool IsPlayBurstAnim;

		// Token: 0x0402305B RID: 143451
		[Nullable(1)]
		private readonly List<UUITexture> TexStarBgList = new List<UUITexture>();

		// Token: 0x0402305C RID: 143452
		[Nullable(1)]
		private readonly List<UUIItem> StarItemList = new List<UUIItem>();

		// Token: 0x0402305D RID: 143453
		private bool IsPlayAniStarReset;

		// Token: 0x0402305E RID: 143454
		private TimerHandle DelayResetStarTimer;

		// Token: 0x0200C1C1 RID: 49601
		[NullableContext(0)]
		private enum EChildType
		{
			// Token: 0x0403BA73 RID: 244339
			SlotBarItemNormal,
			// Token: 0x0403BA74 RID: 244340
			NormalItem,
			// Token: 0x0403BA75 RID: 244341
			MorphItem,
			// Token: 0x0403BA76 RID: 244342
			TexProgress,
			// Token: 0x0403BA77 RID: 244343
			AniDefault,
			// Token: 0x0403BA78 RID: 244344
			AniCharge0,
			// Token: 0x0403BA79 RID: 244345
			AniCharge1,
			// Token: 0x0403BA7A RID: 244346
			AniCharge2,
			// Token: 0x0403BA7B RID: 244347
			AniCharge3,
			// Token: 0x0403BA7C RID: 244348
			AniCharge4,
			// Token: 0x0403BA7D RID: 244349
			AniBurst,
			// Token: 0x0403BA7E RID: 244350
			AniMorphIn,
			// Token: 0x0403BA7F RID: 244351
			AniMorphOut,
			// Token: 0x0403BA80 RID: 244352
			AniWarning,
			// Token: 0x0403BA81 RID: 244353
			AniWarningReset,
			// Token: 0x0403BA82 RID: 244354
			AniMorphBurstOut,
			// Token: 0x0403BA83 RID: 244355
			AniStarReset,
			// Token: 0x0403BA84 RID: 244356
			TexStarBg1,
			// Token: 0x0403BA85 RID: 244357
			TexStarBg2,
			// Token: 0x0403BA86 RID: 244358
			TexStarBg3,
			// Token: 0x0403BA87 RID: 244359
			TexStarBg4,
			// Token: 0x0403BA88 RID: 244360
			StarItem1,
			// Token: 0x0403BA89 RID: 244361
			StarItem2,
			// Token: 0x0403BA8A RID: 244362
			StarItem3,
			// Token: 0x0403BA8B RID: 244363
			StarItem4,
			// Token: 0x0403BA8C RID: 244364
			KeyNode
		}
	}
}
