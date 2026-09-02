using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Morale
{
	// Token: 0x02005711 RID: 22289
	[NullableContext(1)]
	[Nullable(0)]
	public class MoraleBuffItem : UiPanelBase
	{
		// Token: 0x06038BB1 RID: 232369 RVA: 0x00E5D418 File Offset: 0x00E5B618
		public UniTask Init(UUIItem item, MoraleBuffData data)
		{
			MoraleBuffItem.<Init>d__3 <Init>d__;
			<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Init>d__.<>4__this = this;
			<Init>d__.item = item;
			<Init>d__.data = data;
			<Init>d__.<>1__state = -1;
			<Init>d__.<>t__builder.Start<MoraleBuffItem.<Init>d__3>(ref <Init>d__);
			return <Init>d__.<>t__builder.Task;
		}

		// Token: 0x06038BB2 RID: 232370 RVA: 0x00E5D46C File Offset: 0x00E5B66C
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUISprite)),
				new ValueTuple<int, Type>(1, typeof(UUIExtendToggle)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUITexture)),
				new ValueTuple<int, Type>(6, typeof(UUIText)),
				new ValueTuple<int, Type>(7, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(1, new Action<EToggleState>(this.OnToggleBuffRoot))
			};
		}

		// Token: 0x06038BB3 RID: 232371 RVA: 0x00E5D558 File Offset: 0x00E5B758
		public void UpdateData()
		{
			UUIText text = base.GetText(6);
			if (text != null)
			{
				text.SetText(this.BuffData.Config.LvStage.ToString(), true);
			}
			this.UpdateToggleState();
			this.UpdateState();
		}

		// Token: 0x06038BB4 RID: 232372 RVA: 0x00E5D59C File Offset: 0x00E5B79C
		public void UpdateToggleState()
		{
			EToggleState state = this.BuffData.IsSelect ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
			UUIExtendToggle extendToggle = base.GetExtendToggle(1);
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.SetToggleStateForce(state, false, false, false);
		}

		// Token: 0x06038BB5 RID: 232373 RVA: 0x00E5D5D0 File Offset: 0x00E5B7D0
		public void UpdateState()
		{
			switch (this.BuffData.GetActiveState())
			{
			case EMoraleBuffState.TempActive:
				this.SetStateTempActive();
				return;
			case EMoraleBuffState.Active:
				this.SetStateActive();
				return;
			case EMoraleBuffState.NotActive:
				this.SetStateNotActive();
				return;
			default:
				return;
			}
		}

		// Token: 0x06038BB6 RID: 232374 RVA: 0x00E5D610 File Offset: 0x00E5B810
		public void SetStateActive()
		{
			this.SetStarState(true);
			this.SetLockState(false);
			this.SetStateItemShow(3);
			this.SetIcon(this.BuffData.Config.IconPathActive);
			this.UseIconChangeColor(true);
		}

		// Token: 0x06038BB7 RID: 232375 RVA: 0x00E5D644 File Offset: 0x00E5B844
		public void SetStateTempActive()
		{
			this.SetStarState(true);
			this.SetLockState(false);
			this.SetStateItemShow(2);
			this.SetIcon(this.BuffData.Config.IconPathActive);
			this.UseIconChangeColor(true);
		}

		// Token: 0x06038BB8 RID: 232376 RVA: 0x00E5D678 File Offset: 0x00E5B878
		public void SetStateNotActive()
		{
			this.SetStarState(false);
			this.SetLockState(true);
			this.SetStateItemShow(4);
			this.SetIcon(this.BuffData.Config.IconPathNormal);
			this.UseIconChangeColor(false);
		}

		// Token: 0x06038BB9 RID: 232377 RVA: 0x00E5D6AC File Offset: 0x00E5B8AC
		private void SetStarState(bool show)
		{
			UUISprite sprite = base.GetSprite(0);
			if (sprite == null)
			{
				return;
			}
			sprite.SetUIActive(show);
		}

		// Token: 0x06038BBA RID: 232378 RVA: 0x00E5D6C0 File Offset: 0x00E5B8C0
		private void SetLockState(bool show)
		{
			UUIItem item = base.GetItem(7);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(show);
		}

		// Token: 0x06038BBB RID: 232379 RVA: 0x00E5D6D4 File Offset: 0x00E5B8D4
		private void SetStateItemShow(int index)
		{
			foreach (int num in new int[]
			{
				3,
				2,
				4
			})
			{
				UUIItem item = base.GetItem(num);
				if (item != null)
				{
					item.SetUIActive(index == num);
				}
			}
		}

		// Token: 0x06038BBC RID: 232380 RVA: 0x00E5D71C File Offset: 0x00E5B91C
		private void SetIcon(string path)
		{
			UUITexture texture = base.GetTexture(5);
			base.SetTextureByPath(path, texture, null, null);
		}

		// Token: 0x06038BBD RID: 232381 RVA: 0x00E5D744 File Offset: 0x00E5B944
		private void UseIconChangeColor(bool isUse)
		{
			UUITexture texture = base.GetTexture(5);
			UUIItem uuiitem = texture;
			FColor? fcolor = new FColor?(texture.changeColor);
			uuiitem.SetChangeColor(isUse, fcolor);
		}

		// Token: 0x06038BBE RID: 232382 RVA: 0x00E5D76E File Offset: 0x00E5B96E
		private void OnToggleBuffRoot(EToggleState toggleState)
		{
			Action<MoraleBuffData> clickCallback = this.ClickCallback;
			if (clickCallback == null)
			{
				return;
			}
			clickCallback(this.BuffData);
		}

		// Token: 0x04020540 RID: 132416
		public MoraleBuffData BuffData;

		// Token: 0x04020541 RID: 132417
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Action<MoraleBuffData> ClickCallback;

		// Token: 0x0200B7AD RID: 47021
		[NullableContext(0)]
		private class EChildType
		{
			// Token: 0x04038D01 RID: 232705
			public const int SpriteStarActive = 0;

			// Token: 0x04038D02 RID: 232706
			public const int ToggleBuffRoot = 1;

			// Token: 0x04038D03 RID: 232707
			public const int ItemTempActive = 2;

			// Token: 0x04038D04 RID: 232708
			public const int ItemActive = 3;

			// Token: 0x04038D05 RID: 232709
			public const int ItemUnActive = 4;

			// Token: 0x04038D06 RID: 232710
			public const int TextureIcon = 5;

			// Token: 0x04038D07 RID: 232711
			public const int TextNum = 6;

			// Token: 0x04038D08 RID: 232712
			public const int ItemLock = 7;
		}
	}
}
