using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Menu.KeySettingsView
{
	// Token: 0x020057C7 RID: 22471
	public class KeySettingRowBaseItem : UiPanelBase, IDynamicScrollBaseItem<KeySettingRowData>
	{
		// Token: 0x060391D0 RID: 233936 RVA: 0x00E796C4 File Offset: 0x00E778C4
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIItem))
			};
		}

		// Token: 0x060391D1 RID: 233937 RVA: 0x00E79720 File Offset: 0x00E77920
		[NullableContext(1)]
		public UniTask Init(UUIItem actor)
		{
			KeySettingRowBaseItem.<Init>d__2 <Init>d__;
			<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Init>d__.<>4__this = this;
			<Init>d__.actor = actor;
			<Init>d__.<>1__state = -1;
			<Init>d__.<>t__builder.Start<KeySettingRowBaseItem.<Init>d__2>(ref <Init>d__);
			return <Init>d__.<>t__builder.Task;
		}

		// Token: 0x060391D2 RID: 233938 RVA: 0x00E7976B File Offset: 0x00E7796B
		public void ClearItem()
		{
		}

		// Token: 0x060391D3 RID: 233939 RVA: 0x00E79770 File Offset: 0x00E77970
		[NullableContext(1)]
		public FVector2D GetItemSize(KeySettingRowData data)
		{
			Vector2D vector2D = Vector2D.Create(0.0, 0.0);
			UUIItem uuiitem = null;
			EKeySettingRowType rowType = data.GetRowType();
			if (rowType != EKeySettingRowType.KeyType)
			{
				if (rowType == EKeySettingRowType.KeySetting)
				{
					uuiitem = base.GetItem(2);
				}
			}
			else
			{
				uuiitem = base.GetItem(1);
			}
			if (uuiitem == null)
			{
				return vector2D.ToUeVector2D(false);
			}
			vector2D.X = (double)uuiitem.GetWidth();
			vector2D.Y = (double)uuiitem.GetHeight();
			return vector2D.ToUeVector2D(false);
		}

		// Token: 0x0200B847 RID: 47175
		public class EChidType
		{
			// Token: 0x04038FF2 RID: 233458
			public const int Toggle = 0;

			// Token: 0x04038FF3 RID: 233459
			public const int TitleItem = 1;

			// Token: 0x04038FF4 RID: 233460
			public const int KeySettingItem = 2;
		}
	}
}
