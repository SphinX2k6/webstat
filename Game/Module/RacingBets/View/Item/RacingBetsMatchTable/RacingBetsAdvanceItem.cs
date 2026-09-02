using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.RacingBets.View.Item.RacingBetsMatchTable
{
	// Token: 0x0200529B RID: 21147
	public class RacingBetsAdvanceItem : RacingBetsMatchItemBase
	{
		// Token: 0x0603614E RID: 221518 RVA: 0x00D9D9AC File Offset: 0x00D9BBAC
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText)),
				new ValueTuple<int, Type>(1, typeof(UUIGridLayout)),
				new ValueTuple<int, Type>(2, typeof(UUIItem))
			};
		}

		// Token: 0x0603614F RID: 221519 RVA: 0x00D9DA08 File Offset: 0x00D9BC08
		protected override UniTask OnBeforeStartAsync()
		{
			RacingBetsAdvanceItem.<OnBeforeStartAsync>d__3 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RacingBetsAdvanceItem.<OnBeforeStartAsync>d__3>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0401F124 RID: 127268
		public ERacingBetsMatchTableType MatchTableType = ERacingBetsMatchTableType.GroupMatch;

		// Token: 0x0200B204 RID: 45572
		private class EComponent
		{
			// Token: 0x040372E8 RID: 226024
			public const int TextTitle = 0;

			// Token: 0x040372E9 RID: 226025
			public const int LayoutDango = 1;

			// Token: 0x040372EA RID: 226026
			public const int ItemDango = 2;
		}
	}
}
