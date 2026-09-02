using System;

namespace CSharpScript.Game.LevelGamePlay.StaticScene
{
	// Token: 0x02006ABB RID: 27323
	public class FollowTargetSetting
	{
		// Token: 0x1700A285 RID: 41605
		// (get) Token: 0x060438EB RID: 276715 RVA: 0x0116AFD1 File Offset: 0x011691D1
		// (set) Token: 0x060438EC RID: 276716 RVA: 0x0116AFD9 File Offset: 0x011691D9
		public bool IsFollowTarget { get; set; }

		// Token: 0x1700A286 RID: 41606
		// (get) Token: 0x060438ED RID: 276717 RVA: 0x0116AFE2 File Offset: 0x011691E2
		// (set) Token: 0x060438EE RID: 276718 RVA: 0x0116AFEA File Offset: 0x011691EA
		public bool IsFollowTargetPitch { get; set; }

		// Token: 0x1700A287 RID: 41607
		// (get) Token: 0x060438EF RID: 276719 RVA: 0x0116AFF3 File Offset: 0x011691F3
		// (set) Token: 0x060438F0 RID: 276720 RVA: 0x0116AFFB File Offset: 0x011691FB
		public float PitchFollowSpeed { get; set; }

		// Token: 0x1700A288 RID: 41608
		// (get) Token: 0x060438F1 RID: 276721 RVA: 0x0116B004 File Offset: 0x01169204
		// (set) Token: 0x060438F2 RID: 276722 RVA: 0x0116B00C File Offset: 0x0116920C
		public bool IsFollowTargetYaw { get; set; }

		// Token: 0x1700A289 RID: 41609
		// (get) Token: 0x060438F3 RID: 276723 RVA: 0x0116B015 File Offset: 0x01169215
		// (set) Token: 0x060438F4 RID: 276724 RVA: 0x0116B01D File Offset: 0x0116921D
		public float YawFollowSpeed { get; set; }

		// Token: 0x1700A28A RID: 41610
		// (get) Token: 0x060438F5 RID: 276725 RVA: 0x0116B026 File Offset: 0x01169226
		// (set) Token: 0x060438F6 RID: 276726 RVA: 0x0116B02E File Offset: 0x0116922E
		public bool IsFollowTargetAngle { get; set; }

		// Token: 0x1700A28B RID: 41611
		// (get) Token: 0x060438F7 RID: 276727 RVA: 0x0116B037 File Offset: 0x01169237
		// (set) Token: 0x060438F8 RID: 276728 RVA: 0x0116B03F File Offset: 0x0116923F
		public float AngleFollowSpeed { get; set; }

		// Token: 0x060438F9 RID: 276729 RVA: 0x0116B048 File Offset: 0x01169248
		public FollowTargetSetting(bool isFollowTarget, bool isFollowTargetPitch, float pitchFollowSpeed, bool isFollowTargetYaw, float yawFollowSpeed, bool isFollowTargetAngle, float angleFollowSpeed)
		{
			this.IsFollowTarget = isFollowTarget;
			this.IsFollowTargetPitch = isFollowTargetPitch;
			this.PitchFollowSpeed = pitchFollowSpeed;
			this.IsFollowTargetYaw = isFollowTargetYaw;
			this.YawFollowSpeed = yawFollowSpeed;
			this.IsFollowTargetAngle = isFollowTargetAngle;
			this.AngleFollowSpeed = angleFollowSpeed;
		}
	}
}
