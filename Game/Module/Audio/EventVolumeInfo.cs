using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Audio
{
	// Token: 0x02006168 RID: 24936
	[NullableContext(1)]
	[Nullable(0)]
	public class EventVolumeInfo
	{
		// Token: 0x0603F038 RID: 258104 RVA: 0x010280FC File Offset: 0x010262FC
		public EventVolumeInfo(int handle, string eventName, AActor owner)
		{
			this.Handle = handle;
			this.Event = eventName;
			this.Owner = owner;
		}

		// Token: 0x0603F039 RID: 258105 RVA: 0x0102812C File Offset: 0x0102632C
		public void OnChangeVolume(int volume, RoleVolumeInfo info)
		{
			AActor owner = this.Owner;
			if (owner == null || !owner.IsValid() || this.Volume == volume)
			{
				return;
			}
			this.Volume = volume;
			Singleton<AudioSystem>.Instance.SetRtpcValue("role_skill_music_volume", (float)volume, new SetRtpcValueArgs?(new SetRtpcValueArgs
			{
				Actor = this.Owner,
				TransitionDuration = new int?(2000),
				TransitionFadeCurve = new EAudioFadeCurve?(EAudioFadeCurve.SCurve)
			}));
		}

		// Token: 0x040235AF RID: 144815
		public int Volume = -1;

		// Token: 0x040235B0 RID: 144816
		public int Handle;

		// Token: 0x040235B1 RID: 144817
		public string Event = "";

		// Token: 0x040235B2 RID: 144818
		[Nullable(2)]
		public AActor Owner;
	}
}
