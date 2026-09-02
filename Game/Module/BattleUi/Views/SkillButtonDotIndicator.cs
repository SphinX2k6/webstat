using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02005FC6 RID: 24518
	[NullableContext(2)]
	[Nullable(0)]
	public class SkillButtonDotIndicator : UiPanelBase
	{
		// Token: 0x0603DA73 RID: 252531 RVA: 0x00FB536C File Offset: 0x00FB356C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603DA74 RID: 252532 RVA: 0x00FB53F6 File Offset: 0x00FB35F6
		protected override void OnStart()
		{
			base.SkipDestroyActor = true;
			this.InitTweenAnim(1);
			this.InitTweenAnim(2);
			base.SetUiActive(true);
			base.GetTexture(0).SetUIActive(false);
		}

		// Token: 0x0603DA75 RID: 252533 RVA: 0x00FB5421 File Offset: 0x00FB3621
		protected override void OnBeforeDestroy()
		{
			if (this.DefaultTextureData != null)
			{
				this.SetIconResource(null);
			}
			base.OnBeforeDestroy();
		}

		// Token: 0x0603DA76 RID: 252534 RVA: 0x00FB5438 File Offset: 0x00FB3638
		private void InitTweenAnim(int componentType)
		{
			if (this.TweenAnimPlayer == null)
			{
				this.TweenAnimPlayer = new BattleUiTweenAnimPlayer();
			}
			this.TweenAnimPlayer.InitTweenAnim(componentType, base.GetItem(componentType), false);
		}

		// Token: 0x0603DA77 RID: 252535 RVA: 0x00FB5464 File Offset: 0x00FB3664
		public void SetDotState(bool bIn, bool force = false)
		{
			if (force)
			{
				UUITexture texture = base.GetTexture(0);
				texture.SetUIActive(bIn);
				texture.SetAlpha(bIn > false);
				return;
			}
			if (this.TweenAnimPlayer == null)
			{
				return;
			}
			UUITexture texture2 = base.GetTexture(0);
			bool flag = texture2.bIsUIActive && texture2.GetAlpha() == 1f;
			bool flag2 = !texture2.bIsUIActive || texture2.GetAlpha() == 0f;
			if (bIn && flag)
			{
				return;
			}
			if (!bIn && flag2)
			{
				return;
			}
			if (!texture2.bIsUIActive)
			{
				texture2.SetUIActive(true);
			}
			this.TweenAnimPlayer.StopTweenAnim((!bIn) ? 1 : 2);
			this.TweenAnimPlayer.PlayTweenAnim(bIn ? 1 : 2);
		}

		// Token: 0x0603DA78 RID: 252536 RVA: 0x00FB5514 File Offset: 0x00FB3714
		public void SetIconResource(UTexture textureData)
		{
			UUITexture texture = base.GetTexture(0);
			if (texture == null)
			{
				return;
			}
			if (textureData != null)
			{
				if (this.DefaultTextureData == null)
				{
					this.DefaultTextureData = texture.GetTexture();
				}
				texture.SetTexture(textureData);
				return;
			}
			if (this.DefaultTextureData != null)
			{
				texture.SetTexture(this.DefaultTextureData);
				this.DefaultTextureData = null;
			}
		}

		// Token: 0x040229B2 RID: 141746
		private BattleUiTweenAnimPlayer TweenAnimPlayer;

		// Token: 0x040229B3 RID: 141747
		private UTexture DefaultTextureData;

		// Token: 0x0200C032 RID: 49202
		[NullableContext(0)]
		private enum EDotChildType
		{
			// Token: 0x0403B2A8 RID: 242344
			LightDot,
			// Token: 0x0403B2A9 RID: 242345
			AniIn,
			// Token: 0x0403B2AA RID: 242346
			AniOut
		}
	}
}
