using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.MapRogue
{
	// Token: 0x02005956 RID: 22870
	public class MapRogueFloatTipsView : UiViewBase
	{
		// Token: 0x06039F9B RID: 237467 RVA: 0x00EABFC5 File Offset: 0x00EAA1C5
		[NullableContext(1)]
		public MapRogueFloatTipsView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06039F9C RID: 237468 RVA: 0x00EABFCE File Offset: 0x00EAA1CE
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText))
			};
		}

		// Token: 0x06039F9D RID: 237469 RVA: 0x00EABFF4 File Offset: 0x00EAA1F4
		protected override void OnStart()
		{
			this.Data = (this.OpenParam as IRogueTipsData);
			if (this.Data == null)
			{
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), this.Data.TextId, this.Data.TextParam);
		}

		// Token: 0x06039F9E RID: 237470 RVA: 0x00EAC042 File Offset: 0x00EAA242
		protected override void OnAfterShow()
		{
			base.CloseMe(delegate(bool _)
			{
				IRogueTipsData data = this.Data;
				if (data == null)
				{
					return;
				}
				Action finishCallback = data.FinishCallback;
				if (finishCallback == null)
				{
					return;
				}
				finishCallback();
			});
		}

		// Token: 0x04020DAE RID: 134574
		[Nullable(2)]
		protected IRogueTipsData Data;
	}
}
