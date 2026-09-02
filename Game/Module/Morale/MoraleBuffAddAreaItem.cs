using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Morale
{
	// Token: 0x02005709 RID: 22281
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class MoraleBuffAddAreaItem : GridProxyAbstract<MoraleAreaData>
	{
		// Token: 0x06038B6C RID: 232300 RVA: 0x00E5C714 File Offset: 0x00E5A914
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUISprite)),
				new ValueTuple<int, Type>(3, typeof(UUIItem))
			};
		}

		// Token: 0x06038B6D RID: 232301 RVA: 0x00E5C784 File Offset: 0x00E5A984
		public override void Refresh(MoraleAreaData data, bool isSelected, int gridIndex)
		{
			this.Refresh(data);
		}

		// Token: 0x06038B6E RID: 232302 RVA: 0x00E5C78D File Offset: 0x00E5A98D
		public void Refresh(MoraleAreaData data)
		{
			this.ItemData = data;
			if (this.ItemData.IsAreaBuffActive())
			{
				this.SetActiveState();
				return;
			}
			this.SetLockState();
		}

		// Token: 0x06038B6F RID: 232303 RVA: 0x00E5C7B0 File Offset: 0x00E5A9B0
		public void SetActiveState()
		{
			this.SetSpriteActive(true);
			this.SetRedDotActive(false);
			this.SetTextName(this.ItemData.Config.BuffActiveDesc);
			this.SetAlpha(1f);
		}

		// Token: 0x06038B70 RID: 232304 RVA: 0x00E5C7E1 File Offset: 0x00E5A9E1
		public void SetLockState()
		{
			this.SetSpriteActive(false);
			this.SetRedDotActive(false);
			this.SetTextName(this.ItemData.Config.BuffLockDesc);
			this.SetAlpha(0.3f);
		}

		// Token: 0x06038B71 RID: 232305 RVA: 0x00E5C812 File Offset: 0x00E5AA12
		private void SetSpriteActive(bool isActive)
		{
			UUISprite sprite = base.GetSprite(2);
			if (sprite == null)
			{
				return;
			}
			sprite.SetUIActive(isActive);
		}

		// Token: 0x06038B72 RID: 232306 RVA: 0x00E5C826 File Offset: 0x00E5AA26
		private void SetTextName(string nameKey)
		{
			UUIText text = base.GetText(1);
			if (text == null)
			{
				return;
			}
			text.ShowTextNew(nameKey);
		}

		// Token: 0x06038B73 RID: 232307 RVA: 0x00E5C83A File Offset: 0x00E5AA3A
		private void SetAlpha(float alpha)
		{
			UUIItem item = base.GetItem(0);
			if (item == null)
			{
				return;
			}
			item.SetAlpha(alpha);
		}

		// Token: 0x06038B74 RID: 232308 RVA: 0x00E5C84E File Offset: 0x00E5AA4E
		private void SetRedDotActive(bool isActive)
		{
			UUIItem item = base.GetItem(3);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(isActive);
		}

		// Token: 0x04020533 RID: 132403
		public MoraleAreaData ItemData;

		// Token: 0x0200B7A3 RID: 47011
		[NullableContext(0)]
		private class EChildType
		{
			// Token: 0x04038CC9 RID: 232649
			public const int ItemRoot = 0;

			// Token: 0x04038CCA RID: 232650
			public const int TxtName = 1;

			// Token: 0x04038CCB RID: 232651
			public const int SpriteActive = 2;

			// Token: 0x04038CCC RID: 232652
			public const int ItemRedDot = 3;
		}
	}
}
