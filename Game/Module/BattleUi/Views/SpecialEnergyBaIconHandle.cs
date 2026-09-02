using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x020060F4 RID: 24820
	[NullableContext(2)]
	[Nullable(0)]
	public class SpecialEnergyBaIconHandle
	{
		// Token: 0x0603EB3B RID: 256827 RVA: 0x0100D8C6 File Offset: 0x0100BAC6
		[NullableContext(1)]
		public void Init(UUITexture[] iconTextureList, [Nullable(2)] UUIItem animItem = null)
		{
			this.IconTextureList = iconTextureList;
			this.AnimItem = animItem;
		}

		// Token: 0x0603EB3C RID: 256828 RVA: 0x0100D8D8 File Offset: 0x0100BAD8
		public void SetIcon(string iconPath)
		{
			UUITexture[] iconTextureList = this.IconTextureList;
			for (int i = 0; i < iconTextureList.Length; i++)
			{
				iconTextureList[i].SetUIActive(false);
			}
			if (string.IsNullOrEmpty(iconPath))
			{
				return;
			}
			this.LoadIconId = Singleton<ResourceSystem>.Instance.LoadAsync<UTexture2D>(iconPath, delegate([Nullable(2)] UTexture2D iconTextureData, string _)
			{
				this.LoadIconId = -1;
				if (iconTextureData == null)
				{
					return;
				}
				foreach (UUITexture uuitexture in this.IconTextureList)
				{
					uuitexture.SetUIActive(true);
					uuitexture.SetTexture(iconTextureData);
				}
			}, 103, "js_undefined");
		}

		// Token: 0x0603EB3D RID: 256829 RVA: 0x0100D930 File Offset: 0x0100BB30
		public void PlayEndAnim(bool isPlay)
		{
			if (this.IsPlayingEndAnim == isPlay)
			{
				return;
			}
			this.IsPlayingEndAnim = isPlay;
			this.InitTweenAnim();
			if (isPlay)
			{
				using (List<ULGUIPlayTweenComponent>.Enumerator enumerator = this.AnimationList.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						ULGUIPlayTweenComponent ulguiplayTweenComponent = enumerator.Current;
						ulguiplayTweenComponent.Play();
					}
					return;
				}
			}
			foreach (ULGUIPlayTweenComponent ulguiplayTweenComponent2 in this.AnimationList)
			{
				ulguiplayTweenComponent2.Stop();
			}
			UUITexture[] iconTextureList = this.IconTextureList;
			for (int i = 0; i < iconTextureList.Length; i++)
			{
				iconTextureList[i].SetAlpha(1f);
			}
		}

		// Token: 0x0603EB3E RID: 256830 RVA: 0x0100D9FC File Offset: 0x0100BBFC
		private void InitTweenAnim()
		{
			if (this.AnimationList != null)
			{
				return;
			}
			this.AnimationList = new List<ULGUIPlayTweenComponent>();
			if (this.AnimItem != null)
			{
				TArray<UActorComponent> tarray = this.AnimItem.GetOwner().K2_GetComponentsByClass(ULGUIPlayTweenComponent.StaticClass());
				for (int i = 0; i < tarray.Num(); i++)
				{
					ULGUIPlayTweenComponent item = tarray.Get(i) as ULGUIPlayTweenComponent;
					this.AnimationList.Add(item);
				}
			}
		}

		// Token: 0x0603EB3F RID: 256831 RVA: 0x0100DA6A File Offset: 0x0100BC6A
		public void OnBeforeDestroy()
		{
			this.PlayEndAnim(false);
			if (this.LoadIconId != -1)
			{
				Singleton<ResourceSystem>.Instance.CancelAsyncLoad(this.LoadIconId);
				this.LoadIconId = -1;
			}
		}

		// Token: 0x040232A1 RID: 144033
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private UUITexture[] IconTextureList;

		// Token: 0x040232A2 RID: 144034
		private UUIItem AnimItem;

		// Token: 0x040232A3 RID: 144035
		private int LoadIconId = -1;

		// Token: 0x040232A4 RID: 144036
		private bool IsPlayingEndAnim;

		// Token: 0x040232A5 RID: 144037
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private List<ULGUIPlayTweenComponent> AnimationList;
	}
}
