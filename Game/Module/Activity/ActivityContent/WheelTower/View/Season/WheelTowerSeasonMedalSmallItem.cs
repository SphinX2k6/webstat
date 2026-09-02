using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.WheelTower.View.Season
{
	// Token: 0x0200623A RID: 25146
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class WheelTowerSeasonMedalSmallItem : GridProxyAbstract<IWheelTowerMedalItemData>
	{
		// Token: 0x0603F693 RID: 259731 RVA: 0x01040B44 File Offset: 0x0103ED44
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUITexture));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603F694 RID: 259732 RVA: 0x01040BF0 File Offset: 0x0103EDF0
		public override void Refresh(IWheelTowerMedalItemData data, bool isSelected, int gridIndex)
		{
			IWheelTowerMedalGroupData medalGroupData = ModelBase<WheelTowerModel>.Instance.GetMedalGroupData(data.GroupId);
			if (medalGroupData == null)
			{
				return;
			}
			UUITexture texture = base.GetTexture(2);
			if (texture != null)
			{
				texture.SetUIActive(medalGroupData.IsMaxLevel);
			}
			UUITexture texture2 = base.GetTexture(3);
			if (texture2 != null)
			{
				texture2.SetUIActive(!medalGroupData.IsMaxLevel);
			}
			if (medalGroupData.CurrentMedalId == 0)
			{
				return;
			}
			NewTowerMedal? medalConfigById = ConfigBase<WheelTowerConfig>.Instance.GetMedalConfigById(medalGroupData.CurrentMedalId);
			if (medalConfigById == null)
			{
				return;
			}
			base.SetTextureByPath(medalConfigById.Value.Background, base.GetTexture(0), null, null);
			base.SetTextureByPath(medalConfigById.Value.Icon, base.GetTexture(1), null, null);
		}
	}
}
