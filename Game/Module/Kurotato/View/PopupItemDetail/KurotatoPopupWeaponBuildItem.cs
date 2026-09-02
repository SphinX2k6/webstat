using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Kurotato.View.PopupItemDetail
{
	// Token: 0x02005A8C RID: 23180
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class KurotatoPopupWeaponBuildItem : GridProxyAbstract<IKurotatoWeaponBuildInfoPanel>
	{
		// Token: 0x0603AA7A RID: 240250 RVA: 0x00EDCD48 File Offset: 0x00EDAF48
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIVerticalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603AA7B RID: 240251 RVA: 0x00EDCDD2 File Offset: 0x00EDAFD2
		protected override void OnStart()
		{
			this.BuildInfoLayout = new GenericLayout<InfoItem, IInfoItemData>(base.GetVerticalLayout(1), () => new InfoItem(), null, false, true);
		}

		// Token: 0x0603AA7C RID: 240252 RVA: 0x00EDCE08 File Offset: 0x00EDB008
		[NullableContext(1)]
		public override void Refresh(IKurotatoWeaponBuildInfoPanel data, bool isSelected, int gridIndex)
		{
			int weaponBuildLevelByBuildId = ModelBase<KurotatoModel>.Instance.GetWeaponBuildLevelByBuildId(data.BuildId);
			KurotatoWeaponBuild value = ConfigBase<KurotatoConfig>.Instance.GetWeaponBuildById(data.BuildId).Value;
			base.GetText(0).ShowTextNew(value.Name);
			List<IReadOnlyList<int>> list = new List<IReadOnlyList<int>>
			{
				value.GetOneEffectsArray() ?? Array.Empty<int>(),
				value.GetTwoEffectsArray() ?? Array.Empty<int>(),
				value.GetThreeEffectArray() ?? Array.Empty<int>(),
				value.GetFourEffectArray() ?? Array.Empty<int>(),
				value.GetFiveEffectArray() ?? Array.Empty<int>(),
				value.GetSixEffectArray() ?? Array.Empty<int>()
			};
			List<IInfoItemData> list2 = new List<IInfoItemData>();
			for (int i = 0; i < list.Count; i++)
			{
				List<IKurotatoAttrDisplay> itemAttrDisplayList = KurotatoUtil.GetItemAttrDisplayList(list[i], true, true, false);
				List<string> list3 = new List<string>();
				foreach (IKurotatoAttrDisplay kurotatoAttrDisplay in itemAttrDisplayList)
				{
					list3.Add(kurotatoAttrDisplay.Text);
				}
				string description = string.Join(",", list3);
				InfoItemData infoItemData = new InfoItemData
				{
					Level = i + 1,
					Description = description,
					BuildLevel = weaponBuildLevelByBuildId,
					IsArrowLevel = false
				};
				if (!StringUtils.IsEmpty(infoItemData.Description))
				{
					list2.Add(infoItemData);
				}
			}
			int num = -1;
			for (int j = list2.Count - 1; j >= 0; j--)
			{
				if (list2[j].Level <= weaponBuildLevelByBuildId)
				{
					num = j;
					break;
				}
			}
			if (num >= 0)
			{
				list2[num].IsArrowLevel = true;
			}
			this.BuildInfoLayout.RefreshByData(list2, null, false);
		}

		// Token: 0x040212C8 RID: 135880
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<InfoItem, IInfoItemData> BuildInfoLayout;

		// Token: 0x0200BA78 RID: 47736
		private enum EChildComp
		{
			// Token: 0x0403992D RID: 235821
			TextName,
			// Token: 0x0403992E RID: 235822
			PanelVerticalLayout,
			// Token: 0x0403992F RID: 235823
			TextDesc
		}
	}
}
