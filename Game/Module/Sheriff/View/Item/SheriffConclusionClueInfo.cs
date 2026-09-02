using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Sheriff.View.Item
{
	// Token: 0x02004FE7 RID: 20455
	public class SheriffConclusionClueInfo : GridProxyAbstract<int>
	{
		// Token: 0x06034BCE RID: 216014 RVA: 0x00D3B104 File Offset: 0x00D39304
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

		// Token: 0x06034BCF RID: 216015 RVA: 0x00D3B14C File Offset: 0x00D3934C
		public override void Refresh(int data, bool isSelected, int gridIndex)
		{
			SheriffClue? clueConfigById = ConfigBase<SheriffConfig>.Instance.GetClueConfigById(data);
			if (clueConfigById == null)
			{
				return;
			}
			base.SetTextureByPath(clueConfigById.Value.Icon, base.GetTexture(0), null, null);
		}

		// Token: 0x0200AFC2 RID: 44994
		private static class EClueInfo
		{
			// Token: 0x04036899 RID: 223385
			public const int TexIcon = 0;
		}
	}
}
