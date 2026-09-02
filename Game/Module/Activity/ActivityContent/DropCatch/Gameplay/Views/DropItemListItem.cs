using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DropCatch.Gameplay.Views
{
	// Token: 0x0200690C RID: 26892
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	internal class DropItemListItem : GridProxyAbstract<IDropItemListItemData>
	{
		// Token: 0x06042CB5 RID: 273589 RVA: 0x0112488C File Offset: 0x01122A8C
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUISprite)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIArtText))
			};
		}

		// Token: 0x06042CB6 RID: 273590 RVA: 0x011248E8 File Offset: 0x01122AE8
		public override void Refresh(IDropItemListItemData data, bool isSelected, int gridIndex)
		{
			UUIArtText artText = base.GetArtText(2);
			if (artText != null)
			{
				artText.SetText(data.Count.ToString());
			}
			DropCatchDropItem? dropCatchDropItemById = ConfigBase<DropCatchConfig>.Instance.GetDropCatchDropItemById(data.Id);
			if (dropCatchDropItemById == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.DropCatch;
				ELogAuthor author = ELogAuthor.CB;
				string message = "获取掉落物配置失败";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Id", data.Id);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(1), dropCatchDropItemById.Value.Name, Array.Empty<object>());
			base.TrySetSpriteByPath(dropCatchDropItemById.Value.Icon, base.GetSprite(0), false, null, null);
		}
	}
}
