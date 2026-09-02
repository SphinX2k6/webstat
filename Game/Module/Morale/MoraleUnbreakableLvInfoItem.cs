using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Battle;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Morale
{
	// Token: 0x02005723 RID: 22307
	public class MoraleUnbreakableLvInfoItem : UiPanelBase
	{
		// Token: 0x06038C54 RID: 232532 RVA: 0x00E5FE18 File Offset: 0x00E5E018
		[NullableContext(1)]
		public UniTask Init(UUIItem item)
		{
			MoraleUnbreakableLvInfoItem.<Init>d__1 <Init>d__;
			<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Init>d__.<>4__this = this;
			<Init>d__.item = item;
			<Init>d__.<>1__state = -1;
			<Init>d__.<>t__builder.Start<MoraleUnbreakableLvInfoItem.<Init>d__1>(ref <Init>d__);
			return <Init>d__.<>t__builder.Task;
		}

		// Token: 0x06038C55 RID: 232533 RVA: 0x00E5FE63 File Offset: 0x00E5E063
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIArtText)),
				new ValueTuple<int, Type>(1, typeof(UUIText))
			};
		}

		// Token: 0x06038C56 RID: 232534 RVA: 0x00E5FE9C File Offset: 0x00E5E09C
		protected override void OnStart()
		{
			this.UpdateData();
		}

		// Token: 0x06038C57 RID: 232535 RVA: 0x00E5FEA4 File Offset: 0x00E5E0A4
		public void UpdateData()
		{
			base.GetArtText(0).SetText(ModelBase<MoraleBattleModel>.Instance.GetMoraleIndomitableLevel().ToString());
			UUIText text = base.GetText(1);
			if (text == null)
			{
				return;
			}
			text.ShowTextNew("Morale_title_3");
		}

		// Token: 0x0200B7D5 RID: 47061
		private class EChildType
		{
			// Token: 0x04038DD3 RID: 232915
			public const int ArtTextUnbreakableLv = 0;

			// Token: 0x04038DD4 RID: 232916
			public const int TxtTitle = 1;
		}
	}
}
