using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Common.CardItem.Component
{
	// Token: 0x02005550 RID: 21840
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class EffectCountItem : GridProxyAbstract<IEffectCountItemData>
	{
		// Token: 0x06037A9B RID: 227995 RVA: 0x00E1E6E8 File Offset: 0x00E1C8E8
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIItem))
			};
		}

		// Token: 0x06037A9C RID: 227996 RVA: 0x00E1E742 File Offset: 0x00E1C942
		protected override void OnStart()
		{
			this.Sequence = new UiSequencePlayer(this.RootItem);
			this.Sequence.BindOnEndSequenceEvent(new Action<string>(this.OnSequenceEndEvent));
			base.GetItem(2).SetUIActive(false);
		}

		// Token: 0x06037A9D RID: 227997 RVA: 0x00E1E779 File Offset: 0x00E1C979
		protected override void OnBeforeDestroy()
		{
			this.Sequence.Clear();
		}

		// Token: 0x06037A9E RID: 227998 RVA: 0x00E1E788 File Offset: 0x00E1C988
		private void OnSequenceEndEvent(string sequenceName)
		{
			if (sequenceName == "Use")
			{
				base.GetItem(2).SetUIActive(false);
				base.GetItem(0).SetUIActive(false);
				return;
			}
			if (sequenceName == "Full")
			{
				base.GetItem(0).SetUIActive(false);
			}
		}

		// Token: 0x06037A9F RID: 227999 RVA: 0x00E1E7D7 File Offset: 0x00E1C9D7
		public override void Refresh(IEffectCountItemData data, bool isSelected, int gridIndex)
		{
			base.GetItem(0).SetUIActive(data.IsActive);
		}

		// Token: 0x06037AA0 RID: 228000 RVA: 0x00E1E7EC File Offset: 0x00E1C9EC
		public UniTask ActiveSequence()
		{
			EffectCountItem.<ActiveSequence>d__6 <ActiveSequence>d__;
			<ActiveSequence>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ActiveSequence>d__.<>4__this = this;
			<ActiveSequence>d__.<>1__state = -1;
			<ActiveSequence>d__.<>t__builder.Start<EffectCountItem.<ActiveSequence>d__6>(ref <ActiveSequence>d__);
			return <ActiveSequence>d__.<>t__builder.Task;
		}

		// Token: 0x06037AA1 RID: 228001 RVA: 0x00E1E830 File Offset: 0x00E1CA30
		public UniTask ResetSequence()
		{
			EffectCountItem.<ResetSequence>d__7 <ResetSequence>d__;
			<ResetSequence>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ResetSequence>d__.<>4__this = this;
			<ResetSequence>d__.<>1__state = -1;
			<ResetSequence>d__.<>t__builder.Start<EffectCountItem.<ResetSequence>d__7>(ref <ResetSequence>d__);
			return <ResetSequence>d__.<>t__builder.Task;
		}

		// Token: 0x06037AA2 RID: 228002 RVA: 0x00E1E874 File Offset: 0x00E1CA74
		public UniTask FullSequence()
		{
			EffectCountItem.<FullSequence>d__8 <FullSequence>d__;
			<FullSequence>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<FullSequence>d__.<>4__this = this;
			<FullSequence>d__.<>1__state = -1;
			<FullSequence>d__.<>t__builder.Start<EffectCountItem.<FullSequence>d__8>(ref <FullSequence>d__);
			return <FullSequence>d__.<>t__builder.Task;
		}

		// Token: 0x0401FE64 RID: 130660
		protected UiSequencePlayer Sequence;

		// Token: 0x0200B4DA RID: 46298
		[NullableContext(0)]
		private static class EEffectCountItem
		{
			// Token: 0x04037FB9 RID: 229305
			public const int NormalItem = 0;

			// Token: 0x04037FBA RID: 229306
			public const int ActiveItem = 1;

			// Token: 0x04037FBB RID: 229307
			public const int FullItem = 2;
		}
	}
}
