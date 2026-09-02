using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x02005156 RID: 20822
	[NullableContext(2)]
	[Nullable(0)]
	public class RoguelikePopularEntryDesc : GridProxyAbstract<int>
	{
		// Token: 0x06035985 RID: 219525 RVA: 0x00D76340 File Offset: 0x00D74540
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISizeControlByOther));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06035986 RID: 219526 RVA: 0x00D763A9 File Offset: 0x00D745A9
		protected override void OnStart()
		{
			this.LevelSequencePlayer = new LevelSequencePlayer(base.GetRootItem());
			this.DelegateTweener = global::DelegateUtils.ToManualReleaseDelegate<FLTweenFloatSetterDynamic>(new Action<float>(this.TweenerUpdate));
		}

		// Token: 0x06035987 RID: 219527 RVA: 0x00D763D3 File Offset: 0x00D745D3
		protected override void OnBeforeDestroy()
		{
			this.KillTweener();
			this.KillDelayTimer();
			global::DelegateUtils.ReleaseManualReleaseDelegate(new Action<float>(this.TweenerUpdate));
		}

		// Token: 0x06035988 RID: 219528 RVA: 0x00D763F2 File Offset: 0x00D745F2
		private void TweenerUpdate(float value)
		{
			this.SetProgress(Singleton<MathUtils>.Instance.Clamp(value, 0f, 1f), this.ShowState);
		}

		// Token: 0x06035989 RID: 219529 RVA: 0x00D76418 File Offset: 0x00D74618
		private void SetProgress(float progress, bool isShow)
		{
			float height = this.DefaultHeight * (isShow ? progress : (1f - progress));
			UUIItem rootItem = this.RootItem;
			if (rootItem == null)
			{
				return;
			}
			rootItem.SetHeight(height);
		}

		// Token: 0x0603598A RID: 219530 RVA: 0x00D7644C File Offset: 0x00D7464C
		private void StartTween()
		{
			base.GetUiSizeControlByOther(0).SetEnable(false);
			this.KillTweener();
			this.HeightTweener = ULTweenBPLibrary.FloatTo(GlobalData.World, this.DelegateTweener, 0f, 1f, this.TweenMaxTime, 0f, LTweenEase.OutCubic);
			if (this.HeightTweener != null)
			{
				this.HeightTweener.SetEase(LTweenEase.OutExpo);
				this.HeightTweener.OnCompleteCallBack.Bind(new Action(this.OnTweenerEnd));
			}
			this.IsTween = true;
		}

		// Token: 0x0603598B RID: 219531 RVA: 0x00D764D4 File Offset: 0x00D746D4
		private void OnTweenerEnd()
		{
			if (this.IsTween)
			{
				this.EndTween();
				if (this.ShowState)
				{
					LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
					if (levelSequencePlayer == null)
					{
						return;
					}
					levelSequencePlayer.PlayOrReplaySequenceByName("Start", false, null);
				}
			}
		}

		// Token: 0x0603598C RID: 219532 RVA: 0x00D76518 File Offset: 0x00D74718
		private void EndTween()
		{
			this.IsTween = false;
			this.RootItem.SetAlpha(1f);
			this.SetProgress(1f, this.ShowState);
			base.GetUiSizeControlByOther(0).SetEnable(true);
			base.SetUiActive(this.ShowState);
		}

		// Token: 0x0603598D RID: 219533 RVA: 0x00D76566 File Offset: 0x00D74766
		private void KillTweener()
		{
			if (this.HeightTweener != null)
			{
				this.HeightTweener.Kill(false);
				this.HeightTweener = null;
			}
		}

		// Token: 0x0603598E RID: 219534 RVA: 0x00D76584 File Offset: 0x00D74784
		public override void Refresh(int overviewId, bool isSelected, int gridIndex)
		{
			this.OverviewId = overviewId;
			RoguelikeEntranceViewModel entranceViewModel = ModelBase<RoguelikeModel>.Instance.GetEntranceViewModel();
			this.ShowState = entranceViewModel.GetOverviewIdActiveState(this.OverviewId);
			this.Update(false);
			base.SetUiActive(this.ShowState);
		}

		// Token: 0x0603598F RID: 219535 RVA: 0x00D765C8 File Offset: 0x00D747C8
		private void Update(bool withAnim)
		{
			RoguelikeEntranceViewModel entranceViewModel = ModelBase<RoguelikeModel>.Instance.GetEntranceViewModel();
			RoguelikeConfig instance = ConfigBase<RoguelikeConfig>.Instance;
			RogueHotEntryOverview? rogueHotEntryOverview = (instance != null) ? instance.GetRogueHotEntryOverviewConfig(this.OverviewId) : null;
			if (rogueHotEntryOverview == null)
			{
				return;
			}
			string text = "";
			int type = rogueHotEntryOverview.Value.Type;
			if (type == 1)
			{
				text = ((rogueHotEntryOverview.Value.DescLength > 0) ? rogueHotEntryOverview.Value.Desc(0) : "");
			}
			else if (type == 2)
			{
				int entriesOverviewIdCount = entranceViewModel.GetEntriesOverviewIdCount(this.OverviewId);
				text = ((rogueHotEntryOverview.Value.DescLength > entriesOverviewIdCount - 1) ? rogueHotEntryOverview.Value.Desc(Math.Max(0, entriesOverviewIdCount - 1)) : "");
			}
			List<string> list = new List<string>();
			List<int> entriesOverviewIdParam = entranceViewModel.GetEntriesOverviewIdParam(this.OverviewId);
			bool[] array = rogueHotEntryOverview.Value.ParamShowPercent();
			for (int i = 0; i < entriesOverviewIdParam.Count; i++)
			{
				float num = (float)entriesOverviewIdParam[i] / 10000f;
				if (array.Length <= i || array[i])
				{
					list.Add((num * 100f).ToString());
				}
				else
				{
					list.Add(num.ToString());
				}
			}
			if (StringUtils.IsEmpty(text))
			{
				return;
			}
			string text2 = StringUtils.Format(ConfigMultiTextLang.GetLocalTextNew(text, null), list.ToArray());
			if (text2 == this.CacheDescText)
			{
				return;
			}
			this.CacheDescText = text2;
			base.GetText(1).SetText(text2, true);
			if (withAnim)
			{
				LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
				if (levelSequencePlayer != null)
				{
					levelSequencePlayer.PlayLevelSequenceByName("Start", false, null, false);
				}
			}
			this.DefaultHeight = base.GetRootItem().GetHeight();
		}

		// Token: 0x06035990 RID: 219536 RVA: 0x00D767A4 File Offset: 0x00D749A4
		private void ChangeState(bool showState, bool tween)
		{
			this.ShowState = showState;
			if (showState)
			{
				this.Update(false);
				if (!tween)
				{
					base.SetUiActive(true);
					LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
					if (levelSequencePlayer == null)
					{
						return;
					}
					levelSequencePlayer.PlayOrReplaySequenceByName("Start", false, null);
					return;
				}
				else
				{
					this.RootItem.SetAlpha(0f);
					base.SetUiActive(true);
				}
			}
			else
			{
				LevelSequencePlayer levelSequencePlayer2 = this.LevelSequencePlayer;
				if (levelSequencePlayer2 != null)
				{
					levelSequencePlayer2.PlayOrReplaySequenceByName("Close", false, null);
				}
			}
			this.StartTween();
		}

		// Token: 0x06035991 RID: 219537 RVA: 0x00D7682B File Offset: 0x00D74A2B
		private void UpdateState(bool tween)
		{
			if (!tween)
			{
				this.Update(true);
				return;
			}
			this.DelayTimerHandle = TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
			{
				if (this.ShowState)
				{
					this.Update(true);
				}
			}, this.TweenMaxTime * 1000f, null, null, true, 1f);
		}

		// Token: 0x06035992 RID: 219538 RVA: 0x00D76868 File Offset: 0x00D74A68
		private void KillDelayTimer()
		{
			if (TimerSystem.GameplayTimeInstance.Has(this.DelayTimerHandle))
			{
				TimerSystem.GameplayTimeInstance.Remove(this.DelayTimerHandle);
				this.DelayTimerHandle = null;
			}
		}

		// Token: 0x06035993 RID: 219539 RVA: 0x00D76894 File Offset: 0x00D74A94
		public void RefreshState(bool state, bool delayEmit)
		{
			if (state != this.ShowState)
			{
				this.ChangeState(state, delayEmit);
				return;
			}
			if (state)
			{
				this.UpdateState(delayEmit);
			}
		}

		// Token: 0x06035994 RID: 219540 RVA: 0x00D768B2 File Offset: 0x00D74AB2
		public void Reset()
		{
			this.OnTweenerEnd();
			this.KillDelayTimer();
		}

		// Token: 0x0401EC92 RID: 126098
		public int OverviewId;

		// Token: 0x0401EC93 RID: 126099
		[Nullable(1)]
		private string CacheDescText = "";

		// Token: 0x0401EC94 RID: 126100
		private LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x0401EC95 RID: 126101
		private ULTweener HeightTweener;

		// Token: 0x0401EC96 RID: 126102
		[Nullable(1)]
		private FLTweenFloatSetterDynamic DelegateTweener;

		// Token: 0x0401EC97 RID: 126103
		public bool ShowState = true;

		// Token: 0x0401EC98 RID: 126104
		private bool IsTween;

		// Token: 0x0401EC99 RID: 126105
		private readonly float TweenMaxTime = ConfigCommonParamById.GetFloatConfig("RoguelikeEntryDescTweenTime").GetValueOrDefault(0.1f);

		// Token: 0x0401EC9A RID: 126106
		private float DefaultHeight;

		// Token: 0x0401EC9B RID: 126107
		private TimerHandle DelayTimerHandle;

		// Token: 0x0200B103 RID: 45315
		[NullableContext(0)]
		private class EComponent
		{
			// Token: 0x04036E8C RID: 224908
			public const int ItemSelf = 0;

			// Token: 0x04036E8D RID: 224909
			public const int TxtDesc = 1;
		}
	}
}
