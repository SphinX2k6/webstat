using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Kurotato.View.Overview
{
	// Token: 0x02005A9E RID: 23198
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class KurotatoRoleSkillInfoItem : GridProxyAbstract<IKurotatoRoleSkillInfo>
	{
		// Token: 0x0603AB0C RID: 240396 RVA: 0x00EE0008 File Offset: 0x00EDE208
		protected unsafe override void OnRegisterComponent()
		{
			int num = 1;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int index = 0;
			*span[index] = new ValueTuple<int, Type>(0, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603AB0D RID: 240397 RVA: 0x00EE0050 File Offset: 0x00EDE250
		[NullableContext(1)]
		public override void Refresh(IKurotatoRoleSkillInfo data, bool isSelected, int gridIndex)
		{
			KurotatoProperty value = ConfigBase<KurotatoConfig>.Instance.GetPropertyById(data.AttrId).Value;
			base.GetText(0).SetText(value.Desc, true);
		}

		// Token: 0x0200BA9C RID: 47772
		private enum EChildComp
		{
			// Token: 0x040399E7 RID: 236007
			TextSkillDesc
		}
	}
}
