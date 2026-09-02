using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Morale
{
	// Token: 0x02005715 RID: 22293
	public class MoraleHighMonsterProgressPanel : UiPanelBase
	{
		// Token: 0x06038BEB RID: 232427 RVA: 0x00E5E658 File Offset: 0x00E5C858
		[NullableContext(1)]
		public UniTask Init(UUIItem item)
		{
			MoraleHighMonsterProgressPanel.<Init>d__1 <Init>d__;
			<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Init>d__.<>4__this = this;
			<Init>d__.item = item;
			<Init>d__.<>1__state = -1;
			<Init>d__.<>t__builder.Start<MoraleHighMonsterProgressPanel.<Init>d__1>(ref <Init>d__);
			return <Init>d__.<>t__builder.Task;
		}

		// Token: 0x06038BEC RID: 232428 RVA: 0x00E5E6A3 File Offset: 0x00E5C8A3
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText))
			};
		}

		// Token: 0x06038BED RID: 232429 RVA: 0x00E5E6C8 File Offset: 0x00E5C8C8
		protected override UniTask OnBeforeStartAsync()
		{
			MoraleHighMonsterProgressPanel.<OnBeforeStartAsync>d__3 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<MoraleHighMonsterProgressPanel.<OnBeforeStartAsync>d__3>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06038BEE RID: 232430 RVA: 0x00E5E70B File Offset: 0x00E5C90B
		protected override void OnStart()
		{
		}

		// Token: 0x06038BEF RID: 232431 RVA: 0x00E5E70D File Offset: 0x00E5C90D
		protected override void OnBeforeShow()
		{
		}

		// Token: 0x06038BF0 RID: 232432 RVA: 0x00E5E70F File Offset: 0x00E5C90F
		protected override void OnBeforeDestroy()
		{
		}

		// Token: 0x06038BF1 RID: 232433 RVA: 0x00E5E714 File Offset: 0x00E5C914
		public void UpdateProgress(int? val = null)
		{
			int value = val ?? ModelBase<MoraleModel>.Instance.GetAllHighMonsterProgress();
			int allHighMonsterTotal = ModelBase<MoraleModel>.Instance.GetAllHighMonsterTotal();
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<int>(value);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(allHighMonsterTotal);
			string newText = defaultInterpolatedStringHandler.ToStringAndClear();
			UUIText text = base.GetText(0);
			if (text == null)
			{
				return;
			}
			text.SetText(newText, true);
		}

		// Token: 0x0200B7B7 RID: 47031
		private class EChildType
		{
			// Token: 0x04038D43 RID: 232771
			public const int TextProgress = 0;
		}
	}
}
