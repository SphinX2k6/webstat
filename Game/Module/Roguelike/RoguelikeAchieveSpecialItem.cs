using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x0200512C RID: 20780
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RoguelikeAchieveSpecialItem : GridProxyAbstract<IRoguelikeAchieveTokenItemData>
	{
		// Token: 0x06035801 RID: 219137 RVA: 0x00D6E5F4 File Offset: 0x00D6C7F4
		[NullableContext(1)]
		public override void Refresh(IRoguelikeAchieveTokenItemData data, bool isSelected, int gridIndex)
		{
			RoguelikeConfig instance = ConfigBase<RoguelikeConfig>.Instance;
			RougeMiraclecreation? rougeMiraclecreation = (instance != null) ? instance.GetRoguelikeSpecialConfig(data.GainEntry.ConfigId) : null;
			if (rougeMiraclecreation == null)
			{
				base.GetTexture(0).SetUIActive(false);
				base.GetTexture(1).SetUIActive(false);
				return;
			}
			base.SetTextureByPath(rougeMiraclecreation.Value.Icon, base.GetTexture(1), null, null);
			RougeMiraclecreationColor? roguelikeMiraclecreationColorConfig = ConfigBase<RoguelikeConfig>.Instance.GetRoguelikeMiraclecreationColorConfig(rougeMiraclecreation.Value.ColorType);
			if (roguelikeMiraclecreationColorConfig != null && !string.IsNullOrEmpty(roguelikeMiraclecreationColorConfig.Value.SmallBg))
			{
				base.SetTextureByPath(roguelikeMiraclecreationColorConfig.Value.SmallBg, base.GetTexture(0), null, null);
			}
			base.GetTexture(0).SetUIActive(true);
			base.GetTexture(1).SetUIActive(true);
		}

		// Token: 0x06035802 RID: 219138 RVA: 0x00D6E6F0 File Offset: 0x00D6C8F0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06035803 RID: 219139 RVA: 0x00D6E759 File Offset: 0x00D6C959
		protected override void OnStart()
		{
			base.GetTexture(0).SetUIActive(true);
			base.GetTexture(1).SetUIActive(false);
		}

		// Token: 0x0200B0CB RID: 45259
		private class EComponents
		{
			// Token: 0x04036D87 RID: 224647
			public const int TexBg = 0;

			// Token: 0x04036D88 RID: 224648
			public const int TexIcon = 1;
		}
	}
}
