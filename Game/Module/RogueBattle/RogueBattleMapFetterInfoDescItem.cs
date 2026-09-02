using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.RogueBattle
{
	// Token: 0x020051E0 RID: 20960
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RogueBattleMapFetterInfoDescItem : GridProxyAbstract<IRogueBattleMapFetterDescInfo>
	{
		// Token: 0x06035D51 RID: 220497 RVA: 0x00D8B513 File Offset: 0x00D89713
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUITexture)),
				new ValueTuple<int, Type>(1, typeof(UUIText))
			};
		}

		// Token: 0x06035D52 RID: 220498 RVA: 0x00D8B54C File Offset: 0x00D8974C
		public override void Refresh(IRogueBattleMapFetterDescInfo data, bool isSelected, int gridIndex)
		{
			if (data.Param != null)
			{
				string[] args = data.Param.Split('#', StringSplitOptions.None);
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), data.TextId, args);
			}
			else
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), data.TextId, Array.Empty<object>());
			}
			string resourceId = RogueBattleDefine.FetterTypeIconMap[data.EffectType];
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId);
			base.SetTextureByPath(resourcePath, base.GetTexture(0), null, delegate(bool _)
			{
				this.GetTexture(0).SetColor(FColor.FromHex(this.IconColor[data.IsReached]));
			});
			base.GetText(1).SetColor(FColor.FromHex(this.DescColor[data.IsReached]));
		}

		// Token: 0x0401EE4D RID: 126541
		public readonly Dictionary<bool, string> IconColor = new Dictionary<bool, string>
		{
			{
				true,
				"#FDF6C6"
			},
			{
				false,
				"#C4C4C4"
			}
		};

		// Token: 0x0401EE4E RID: 126542
		public readonly Dictionary<bool, string> DescColor = new Dictionary<bool, string>
		{
			{
				true,
				"#ECE5D8"
			},
			{
				false,
				"#ADADAD"
			}
		};
	}
}
