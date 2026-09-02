using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Battle.View.Field
{
	// Token: 0x020055C7 RID: 21959
	public class PhantomArenaSealItem : UiPanelBase
	{
		// Token: 0x06037F04 RID: 229124 RVA: 0x00E2BE9D File Offset: 0x00E2A09D
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText))
			};
		}

		// Token: 0x06037F05 RID: 229125 RVA: 0x00E2BEC0 File Offset: 0x00E2A0C0
		protected override void OnStart()
		{
			this.Sequence = new UiSequencePlayer(this.RootItem);
			this.Sequence.BindOnEndSequenceEvent(new Action<string>(this.OnSequenceEndEvent));
		}

		// Token: 0x06037F06 RID: 229126 RVA: 0x00E2BEEA File Offset: 0x00E2A0EA
		protected override void OnBeforeDestroy()
		{
			this.Sequence.Clear();
		}

		// Token: 0x06037F07 RID: 229127 RVA: 0x00E2BEF7 File Offset: 0x00E2A0F7
		[NullableContext(1)]
		private void OnSequenceEndEvent(string sequenceName)
		{
			if (sequenceName == "Unlock")
			{
				this.SetActive(false);
			}
		}

		// Token: 0x06037F08 RID: 229128 RVA: 0x00E2BF10 File Offset: 0x00E2A110
		public UniTask ShowSeal(int roundNum)
		{
			PhantomArenaSealItem.<ShowSeal>d__7 <ShowSeal>d__;
			<ShowSeal>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ShowSeal>d__.<>4__this = this;
			<ShowSeal>d__.roundNum = roundNum;
			<ShowSeal>d__.<>1__state = -1;
			<ShowSeal>d__.<>t__builder.Start<PhantomArenaSealItem.<ShowSeal>d__7>(ref <ShowSeal>d__);
			return <ShowSeal>d__.<>t__builder.Task;
		}

		// Token: 0x06037F09 RID: 229129 RVA: 0x00E2BF5C File Offset: 0x00E2A15C
		public UniTask HideSeal()
		{
			PhantomArenaSealItem.<HideSeal>d__8 <HideSeal>d__;
			<HideSeal>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<HideSeal>d__.<>4__this = this;
			<HideSeal>d__.<>1__state = -1;
			<HideSeal>d__.<>t__builder.Start<PhantomArenaSealItem.<HideSeal>d__8>(ref <HideSeal>d__);
			return <HideSeal>d__.<>t__builder.Task;
		}

		// Token: 0x06037F0A RID: 229130 RVA: 0x00E2BFA0 File Offset: 0x00E2A1A0
		public UniTask SetSealText(int roundNum)
		{
			PhantomArenaSealItem.<SetSealText>d__9 <SetSealText>d__;
			<SetSealText>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<SetSealText>d__.<>4__this = this;
			<SetSealText>d__.roundNum = roundNum;
			<SetSealText>d__.<>1__state = -1;
			<SetSealText>d__.<>t__builder.Start<PhantomArenaSealItem.<SetSealText>d__9>(ref <SetSealText>d__);
			return <SetSealText>d__.<>t__builder.Task;
		}

		// Token: 0x06037F0B RID: 229131 RVA: 0x00E2BFEC File Offset: 0x00E2A1EC
		public UniTask RefreshSeal(bool active, int roundNum)
		{
			PhantomArenaSealItem.<RefreshSeal>d__10 <RefreshSeal>d__;
			<RefreshSeal>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshSeal>d__.<>4__this = this;
			<RefreshSeal>d__.active = active;
			<RefreshSeal>d__.roundNum = roundNum;
			<RefreshSeal>d__.<>1__state = -1;
			<RefreshSeal>d__.<>t__builder.Start<PhantomArenaSealItem.<RefreshSeal>d__10>(ref <RefreshSeal>d__);
			return <RefreshSeal>d__.<>t__builder.Task;
		}

		// Token: 0x0401FFF2 RID: 131058
		[Nullable(1)]
		protected UiSequencePlayer Sequence;

		// Token: 0x0401FFF3 RID: 131059
		protected bool IsInSeal;

		// Token: 0x0200B5B5 RID: 46517
		private class EComponentDefine
		{
			// Token: 0x040383A2 RID: 230306
			public const int SealText = 0;
		}
	}
}
