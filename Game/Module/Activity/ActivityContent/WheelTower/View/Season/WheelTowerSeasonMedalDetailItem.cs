using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.WheelTower.View.Season
{
	// Token: 0x02006227 RID: 25127
	public class WheelTowerSeasonMedalDetailItem : UiPanelBase
	{
		// Token: 0x0603F65B RID: 259675 RVA: 0x0103EF94 File Offset: 0x0103D194
		protected unsafe override void OnRegisterComponent()
		{
			int num = 7;
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
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIArtText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603F65C RID: 259676 RVA: 0x0103F0A4 File Offset: 0x0103D2A4
		[NullableContext(1)]
		public void Refresh(IWheelTowerMedalGroupData groupData, int index)
		{
			int currentMedalId = groupData.CurrentMedalId;
			bool uiactive = currentMedalId == 0;
			UUITexture texture = base.GetTexture(1);
			UUITexture texture2 = base.GetTexture(2);
			UUITexture texture3 = base.GetTexture(4);
			UUITexture texture4 = base.GetTexture(5);
			UUITexture texture5 = base.GetTexture(0);
			if (texture5 != null)
			{
				texture5.SetUIActive(uiactive);
			}
			UUITexture texture6 = base.GetTexture(3);
			if (texture6 != null)
			{
				texture6.SetUIActive(uiactive);
			}
			if (texture != null)
			{
				texture.SetUIActive(true);
			}
			if (texture2 != null)
			{
				texture2.SetUIActive(true);
			}
			if (texture3 != null)
			{
				texture3.SetUIActive(true);
			}
			if (texture4 != null)
			{
				texture4.SetUIActive(true);
			}
			int id = (currentMedalId == 0) ? groupData.NextMedalId : currentMedalId;
			NewTowerMedal? medalConfigById = ConfigBase<WheelTowerConfig>.Instance.GetMedalConfigById(id);
			string background = medalConfigById.Value.Background;
			string icon = medalConfigById.Value.Icon;
			base.SetTextureByPath(background, texture, null, null);
			base.SetTextureByPath(icon, texture2, null, null);
			base.SetTextureByPath(background, texture3, null, null);
			base.SetTextureByPath(icon, texture4, null, null);
			UUIArtText artText = base.GetArtText(6);
			if (artText == null)
			{
				return;
			}
			artText.SetText(index.ToString("D2"));
		}
	}
}
