using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Sheriff.View.Item
{
	// Token: 0x02004FEB RID: 20459
	public class SheriffSelectClueItem : GridProxyAbstract<int>
	{
		// Token: 0x06034BE7 RID: 216039 RVA: 0x00D3BA00 File Offset: 0x00D39C00
		protected unsafe override void OnRegisterComponent()
		{
			int num = 1;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int index = 0;
			*span[index] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06034BE8 RID: 216040 RVA: 0x00D3BA48 File Offset: 0x00D39C48
		public override void Refresh(int data, bool isSelected, int gridIndex)
		{
			int? curId = this.CurId;
			if (curId.GetValueOrDefault() == data & curId != null)
			{
				return;
			}
			this.CurId = new int?(data);
			UUIItem texture = base.GetTexture(0);
			curId = this.CurId;
			int num = 0;
			texture.SetUIActive(curId.GetValueOrDefault() > num & curId != null);
			curId = this.CurId;
			num = 0;
			if (curId.GetValueOrDefault() <= num & curId != null)
			{
				return;
			}
			SheriffClue? clueConfigById = ConfigBase<SheriffConfig>.Instance.GetClueConfigById(data);
			if (clueConfigById != null)
			{
				base.SetTextureByPath(clueConfigById.Value.Icon, base.GetTexture(0), null, null);
			}
		}

		// Token: 0x0401E643 RID: 124483
		protected int? CurId;

		// Token: 0x0200AFC6 RID: 44998
		private static class ESelectClueItem
		{
			// Token: 0x040368AB RID: 223403
			public const int TexIcon = 0;
		}
	}
}
