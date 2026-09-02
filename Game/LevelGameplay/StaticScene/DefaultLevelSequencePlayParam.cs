using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.StaticScene
{
	// Token: 0x02006ABC RID: 27324
	[NullableContext(1)]
	[Nullable(0)]
	public class DefaultLevelSequencePlayParam
	{
		// Token: 0x1700A28C RID: 41612
		// (get) Token: 0x060438FA RID: 276730 RVA: 0x0116B085 File Offset: 0x01169285
		// (set) Token: 0x060438FB RID: 276731 RVA: 0x0116B08D File Offset: 0x0116928D
		public float InTime { get; set; }

		// Token: 0x1700A28D RID: 41613
		// (get) Token: 0x060438FC RID: 276732 RVA: 0x0116B096 File Offset: 0x01169296
		// (set) Token: 0x060438FD RID: 276733 RVA: 0x0116B09E File Offset: 0x0116929E
		public float OutTime { get; set; }

		// Token: 0x1700A28E RID: 41614
		// (get) Token: 0x060438FE RID: 276734 RVA: 0x0116B0A7 File Offset: 0x011692A7
		// (set) Token: 0x060438FF RID: 276735 RVA: 0x0116B0AF File Offset: 0x011692AF
		public float SmoothFactor { get; set; }

		// Token: 0x1700A28F RID: 41615
		// (get) Token: 0x06043900 RID: 276736 RVA: 0x0116B0B8 File Offset: 0x011692B8
		// (set) Token: 0x06043901 RID: 276737 RVA: 0x0116B0C0 File Offset: 0x011692C0
		public float SmoothDelta { get; set; }

		// Token: 0x1700A290 RID: 41616
		// (get) Token: 0x06043902 RID: 276738 RVA: 0x0116B0C9 File Offset: 0x011692C9
		// (set) Token: 0x06043903 RID: 276739 RVA: 0x0116B0D1 File Offset: 0x011692D1
		public BindTargetSetting BindSetting { get; set; }

		// Token: 0x1700A291 RID: 41617
		// (get) Token: 0x06043904 RID: 276740 RVA: 0x0116B0DA File Offset: 0x011692DA
		// (set) Token: 0x06043905 RID: 276741 RVA: 0x0116B0E2 File Offset: 0x011692E2
		public FollowTargetSetting FollowSetting { get; set; }

		// Token: 0x1700A292 RID: 41618
		// (get) Token: 0x06043906 RID: 276742 RVA: 0x0116B0EB File Offset: 0x011692EB
		// (set) Token: 0x06043907 RID: 276743 RVA: 0x0116B0F3 File Offset: 0x011692F3
		public TsBaseCharacter Target { get; set; }

		// Token: 0x06043908 RID: 276744 RVA: 0x0116B0FC File Offset: 0x011692FC
		public DefaultLevelSequencePlayParam(float inTime, float outTime, float smoothFactor, float smoothDelta, BindTargetSetting bindSetting, FollowTargetSetting followSetting, TsBaseCharacter target)
		{
			this.InTime = inTime;
			this.OutTime = outTime;
			this.SmoothFactor = smoothFactor;
			this.SmoothDelta = smoothDelta;
			this.BindSetting = bindSetting;
			this.FollowSetting = followSetting;
			this.Target = target;
		}

		// Token: 0x04025BF7 RID: 154615
		public readonly int MaxDelayUpdateFrame = 4;

		// Token: 0x04025BF8 RID: 154616
		public Rotator InitPlayerRotator = Rotator.Create();

		// Token: 0x04025BF9 RID: 154617
		public Vector InitPlayerFloorLocation = Vector.Create();

		// Token: 0x04025BFA RID: 154618
		public int DelayUpdateFrame;

		// Token: 0x04025BFB RID: 154619
		public float PlayedTime;

		// Token: 0x04025BFC RID: 154620
		public float TimeLength;

		// Token: 0x04025BFD RID: 154621
		public bool HasLastFrameFloorLocationZ;

		// Token: 0x04025BFE RID: 154622
		public double LastFrameFloorLocationZ;
	}
}
