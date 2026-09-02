using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Area;
using CSharpScript.Game.Module.Map;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.WorldMap;
using Cysharp.Threading.Tasks;
using UnrealEngine;

namespace Ui.WorldMap.View.Component
{
	// Token: 0x020043B6 RID: 17334
	public class WorldMapSubMapItem : GridProxyAbstract<MultiMap>
	{
		// Token: 0x0602E1B7 RID: 188855 RVA: 0x00AD6E28 File Offset: 0x00AD5028
		public override void Refresh(MultiMap data, bool isSelected, int gridIndex)
		{
			this.MultiMapConfigId = data.Id;
			base.GridIndex = gridIndex;
			UUIExtendToggle extendToggle = base.GetExtendToggle(3);
			if (extendToggle != null)
			{
				extendToggle.SetToggleState(isSelected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), data.FloorName, Array.Empty<object>());
			int currentAreaId = ModelBase<AreaModel>.Instance.GetCurrentAreaId(null);
			MultiMap? subMapConfigByAreaId = ConfigBase<MapConfig>.Instance.GetSubMapConfigByAreaId(currentAreaId);
			bool flag = data.GetAreaBytes().Contains(currentAreaId);
			if (flag || (!flag && data.Floor == 0 && subMapConfigByAreaId == null))
			{
				string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_MultiMapCurrentAreaIcon");
				if (!StringUtils.IsEmpty(resourcePath))
				{
					UUISprite sprite = base.GetSprite(0);
					object obj;
					if (sprite == null)
					{
						obj = null;
					}
					else
					{
						AActor owner = sprite.GetOwner();
						obj = ((owner != null) ? owner.GetComponentByClass(UUIExtendToggleSpriteTransition.StaticClass()) : null);
					}
					UUIExtendToggleSpriteTransition uiExtendToggleSpriteTransition = obj as UUIExtendToggleSpriteTransition;
					base.SetExtendToggleSpriteTransitionByPath(resourcePath, uiExtendToggleSpriteTransition, null).Forget();
					this.SetSpriteByPath(resourcePath, base.GetSprite(1), false, null, null);
					return;
				}
			}
			else if (!StringUtils.IsEmpty(data.FloorIcon))
			{
				string resourcePath2 = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(data.FloorIcon);
				if (!StringUtils.IsEmpty(resourcePath2))
				{
					UUISprite sprite2 = base.GetSprite(0);
					object obj2;
					if (sprite2 == null)
					{
						obj2 = null;
					}
					else
					{
						AActor owner2 = sprite2.GetOwner();
						obj2 = ((owner2 != null) ? owner2.GetComponentByClass(UUIExtendToggleSpriteTransition.StaticClass()) : null);
					}
					UUIExtendToggleSpriteTransition uiExtendToggleSpriteTransition2 = obj2 as UUIExtendToggleSpriteTransition;
					base.SetExtendToggleSpriteTransitionByPath(resourcePath2, uiExtendToggleSpriteTransition2, null).Forget();
					this.SetSpriteByPath(resourcePath2, base.GetSprite(1), false, null, null);
				}
			}
		}

		// Token: 0x0602E1B8 RID: 188856 RVA: 0x00AD6FE8 File Offset: 0x00AD51E8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIExtendToggle));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0602E1B9 RID: 188857 RVA: 0x00AD7093 File Offset: 0x00AD5293
		protected override void OnStart()
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(3);
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.OnStateChange.Add(new Action<EToggleState>(this.OnToggleStateChange));
		}

		// Token: 0x0602E1BA RID: 188858 RVA: 0x00AD70B8 File Offset: 0x00AD52B8
		private void OnToggleStateChange(EToggleState state)
		{
			if (state == EToggleState.ETT_Checked)
			{
				ModelBase<WorldMapModel>.Instance.WorldMapCurrentMultiMapId = new int?(this.MultiMapConfigId);
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.WorldMapSelectMultiMap, this.MultiMapConfigId);
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.WorldMapSubMapChanged, base.GridIndex);
			}
		}

		// Token: 0x0602E1BB RID: 188859 RVA: 0x00AD710A File Offset: 0x00AD530A
		public override void OnSelected(bool fireEvent)
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(3);
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.SetToggleState(EToggleState.ETT_Checked, fireEvent, false, false);
		}

		// Token: 0x0602E1BC RID: 188860 RVA: 0x00AD7122 File Offset: 0x00AD5322
		public override void OnDeselected(bool fireEvent)
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(3);
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.SetToggleState(EToggleState.ETT_UnChecked, fireEvent, false, false);
		}

		// Token: 0x0401A10B RID: 106763
		public int MultiMapConfigId;

		// Token: 0x0200A625 RID: 42533
		private enum EWorldMapSubMapItemDefine
		{
			// Token: 0x04033614 RID: 210452
			SpriteIcon,
			// Token: 0x04033615 RID: 210453
			SpriteAnimIcon,
			// Token: 0x04033616 RID: 210454
			TextName,
			// Token: 0x04033617 RID: 210455
			ExtendToggle
		}
	}
}
