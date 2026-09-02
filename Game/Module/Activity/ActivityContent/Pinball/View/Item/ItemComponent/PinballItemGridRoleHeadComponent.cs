using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Item.ItemComponent
{
	// Token: 0x02006620 RID: 26144
	public class PinballItemGridRoleHeadComponent : PinballItemGridComponentBase
	{
		// Token: 0x06041533 RID: 267571 RVA: 0x010C1468 File Offset: 0x010BF668
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

		// Token: 0x06041534 RID: 267572 RVA: 0x010C14B0 File Offset: 0x010BF6B0
		[NullableContext(2)]
		protected override string OnGetResourceId()
		{
			return "UiItem_ItemBaseRole";
		}

		// Token: 0x06041535 RID: 267573 RVA: 0x010C14B8 File Offset: 0x010BF6B8
		[NullableContext(1)]
		protected override void OnRefresh(params object[] args)
		{
			int num = (int)args[0];
			if (num == 0)
			{
				this.SetActive(false);
				return;
			}
			PinballConfig instance = ConfigBase<PinballConfig>.Instance;
			PinballRoleConfig? pinballRoleConfig = (instance != null) ? instance.GetPinballRoleConfigById(num) : null;
			if (pinballRoleConfig == null)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module = ELogModule.PinballBattle;
				ELogAuthor author = ELogAuthor.CB;
				string message = "星弹奇游角色配置不存在";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("roleId", num);
				instance2.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				this.SetActive(false);
				return;
			}
			this.SetActive(true);
			base.TrySetTextureByPath(pinballRoleConfig.Value.SmallIcon, base.GetTexture(0), null, null);
		}

		// Token: 0x0200C64D RID: 50765
		private enum EComponent
		{
			// Token: 0x0403D0A6 RID: 250022
			TexRoleIcon
		}
	}
}
