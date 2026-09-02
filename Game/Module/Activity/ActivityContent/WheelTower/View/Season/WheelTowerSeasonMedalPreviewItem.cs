using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.WheelTower.View.Season
{
	// Token: 0x02006236 RID: 25142
	public class WheelTowerSeasonMedalPreviewItem : UiPanelBase
	{
		// Token: 0x0603F681 RID: 259713 RVA: 0x010403CC File Offset: 0x0103E5CC
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

		// Token: 0x0603F682 RID: 259714 RVA: 0x01040478 File Offset: 0x0103E678
		[NullableContext(1)]
		public void Refresh(IWheelTowerMedalGroupData group, bool isActive, FColor highlightColor)
		{
			NewTowerMedal? lastMedalConfigByGroupId = WheelTowerUtil.GetLastMedalConfigByGroupId(group.GroupId);
			if (lastMedalConfigByGroupId != null)
			{
				base.SetTextureByPath(lastMedalConfigByGroupId.Value.Icon, base.GetTexture(1), null, null);
				base.SetTextureByPath(lastMedalConfigByGroupId.Value.Background, base.GetTexture(0), null, null);
			}
			UUITexture texture = base.GetTexture(2);
			if (texture != null)
			{
				texture.SetUIActive(isActive);
			}
			if (isActive && texture != null)
			{
				texture.SetColor(highlightColor);
			}
			UUITexture texture2 = base.GetTexture(3);
			if (texture2 == null)
			{
				return;
			}
			texture2.SetUIActive(!group.IsMaxLevel);
		}
	}
}
