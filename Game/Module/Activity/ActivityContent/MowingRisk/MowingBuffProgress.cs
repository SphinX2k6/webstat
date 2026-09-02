using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MowingRisk
{
	// Token: 0x020066A2 RID: 26274
	[NullableContext(1)]
	[Nullable(0)]
	public class MowingBuffProgress : UiPanelBase
	{
		// Token: 0x060419C5 RID: 268741 RVA: 0x010D2A68 File Offset: 0x010D0C68
		protected unsafe override void OnRegisterComponent()
		{
			int num = 6;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x060419C6 RID: 268742 RVA: 0x010D2B58 File Offset: 0x010D0D58
		protected override UniTask OnBeforeStartAsync()
		{
			MowingBuffProgress.<OnBeforeStartAsync>d__11 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<MowingBuffProgress.<OnBeforeStartAsync>d__11>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060419C7 RID: 268743 RVA: 0x010D2B9C File Offset: 0x010D0D9C
		private UniTask CreateBuffItem(int index)
		{
			MowingBuffProgress.<CreateBuffItem>d__12 <CreateBuffItem>d__;
			<CreateBuffItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateBuffItem>d__.<>4__this = this;
			<CreateBuffItem>d__.index = index;
			<CreateBuffItem>d__.<>1__state = -1;
			<CreateBuffItem>d__.<>t__builder.Start<MowingBuffProgress.<CreateBuffItem>d__12>(ref <CreateBuffItem>d__);
			return <CreateBuffItem>d__.<>t__builder.Task;
		}

		// Token: 0x060419C8 RID: 268744 RVA: 0x010D2BE8 File Offset: 0x010D0DE8
		public void RefreshByCustomData(IMowingBuffProgressData data)
		{
			MowingBuffProgress.<>c__DisplayClass13_0 CS$<>8__locals1 = new MowingBuffProgress.<>c__DisplayClass13_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.data = data;
			UiAsyncTask task = new UiAsyncTask("MowingBuffProgress.RefreshByCustomDataAsync", delegate()
			{
				MowingBuffProgress.<>c__DisplayClass13_0.<<RefreshByCustomData>b__0>d <<RefreshByCustomData>b__0>d;
				<<RefreshByCustomData>b__0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
				<<RefreshByCustomData>b__0>d.<>4__this = CS$<>8__locals1;
				<<RefreshByCustomData>b__0>d.<>1__state = -1;
				<<RefreshByCustomData>b__0>d.<>t__builder.Start<MowingBuffProgress.<>c__DisplayClass13_0.<<RefreshByCustomData>b__0>d>(ref <<RefreshByCustomData>b__0>d);
				return <<RefreshByCustomData>b__0>d.<>t__builder.Task;
			}, null);
			base.RunAsyncTask(task);
		}

		// Token: 0x060419C9 RID: 268745 RVA: 0x010D2C2C File Offset: 0x010D0E2C
		public UniTask RefreshByCustomDataAsync(IMowingBuffProgressData data)
		{
			MowingBuffProgress.<RefreshByCustomDataAsync>d__14 <RefreshByCustomDataAsync>d__;
			<RefreshByCustomDataAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshByCustomDataAsync>d__.<>4__this = this;
			<RefreshByCustomDataAsync>d__.data = data;
			<RefreshByCustomDataAsync>d__.<>1__state = -1;
			<RefreshByCustomDataAsync>d__.<>t__builder.Start<MowingBuffProgress.<RefreshByCustomDataAsync>d__14>(ref <RefreshByCustomDataAsync>d__);
			return <RefreshByCustomDataAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060419CA RID: 268746 RVA: 0x010D2C78 File Offset: 0x010D0E78
		public UniTask PlayStartSequenceAsync()
		{
			MowingBuffProgress.<PlayStartSequenceAsync>d__15 <PlayStartSequenceAsync>d__;
			<PlayStartSequenceAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayStartSequenceAsync>d__.<>4__this = this;
			<PlayStartSequenceAsync>d__.<>1__state = -1;
			<PlayStartSequenceAsync>d__.<>t__builder.Start<MowingBuffProgress.<PlayStartSequenceAsync>d__15>(ref <PlayStartSequenceAsync>d__);
			return <PlayStartSequenceAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060419CB RID: 268747 RVA: 0x010D2CBC File Offset: 0x010D0EBC
		public UniTask PlayProgressTween()
		{
			MowingBuffProgress.<PlayProgressTween>d__16 <PlayProgressTween>d__;
			<PlayProgressTween>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayProgressTween>d__.<>4__this = this;
			<PlayProgressTween>d__.<>1__state = -1;
			<PlayProgressTween>d__.<>t__builder.Start<MowingBuffProgress.<PlayProgressTween>d__16>(ref <PlayProgressTween>d__);
			return <PlayProgressTween>d__.<>t__builder.Task;
		}

		// Token: 0x060419CC RID: 268748 RVA: 0x010D2D00 File Offset: 0x010D0F00
		private void PlayFillAmount(float value)
		{
			base.GetSprite(1).SetFillAmount(value);
			if (this.BuffNodeTweenDataQueue.Size == 0)
			{
				return;
			}
			BuffNodeTweenData front = this.BuffNodeTweenDataQueue.Front;
			if (front == null)
			{
				return;
			}
			if (value >= front.Percentage)
			{
				front.BuffNodeItem.PlayUnlockSequence();
				this.BuffNodeTweenDataQueue.Pop();
			}
		}

		// Token: 0x060419CD RID: 268749 RVA: 0x010D2D58 File Offset: 0x010D0F58
		private void CheckKillTweener()
		{
			if (this.Tweener != null && this.Tweener.IsValid())
			{
				this.Tweener.Kill(false);
			}
			this.Tweener = null;
		}

		// Token: 0x060419CE RID: 268750 RVA: 0x010D2D82 File Offset: 0x010D0F82
		protected override void OnBeforeDestroy()
		{
			global::DelegateUtils.ReleaseManualReleaseDelegate(new Action<float>(this.PlayFillAmount));
			this.CheckKillTweener();
		}

		// Token: 0x04024A2F RID: 150063
		private readonly List<MowingBuffUnit> BuffUnitList = new List<MowingBuffUnit>();

		// Token: 0x04024A30 RID: 150064
		private MowingBuffIntroduce BuffIntroduce;

		// Token: 0x04024A31 RID: 150065
		private UiSequencePlayer Player;

		// Token: 0x04024A32 RID: 150066
		[Nullable(2)]
		protected FLTweenFloatSetterDynamic Delegate;

		// Token: 0x04024A33 RID: 150067
		[Nullable(2)]
		protected ULTweener Tweener;

		// Token: 0x04024A34 RID: 150068
		private bool NeedPlayTween;

		// Token: 0x04024A35 RID: 150069
		private float FromProgress;

		// Token: 0x04024A36 RID: 150070
		private float ToProgress;

		// Token: 0x04024A37 RID: 150071
		private readonly Queue<BuffNodeTweenData> BuffNodeTweenDataQueue = new Queue<BuffNodeTweenData>(4);

		// Token: 0x0200C6B2 RID: 50866
		[NullableContext(0)]
		private class EComponent
		{
			// Token: 0x0403D2EA RID: 250602
			public const int CountText = 0;

			// Token: 0x0403D2EB RID: 250603
			public const int ProgressSprite = 1;

			// Token: 0x0403D2EC RID: 250604
			public const int BuffLayout = 2;

			// Token: 0x0403D2ED RID: 250605
			public const int UpwardBuffTemplateItem = 3;

			// Token: 0x0403D2EE RID: 250606
			public const int DownwardBuffTemplateItem = 4;

			// Token: 0x0403D2EF RID: 250607
			public const int BuffIntroduceItem = 5;
		}
	}
}
