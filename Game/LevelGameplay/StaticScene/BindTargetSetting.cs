using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter.Camera.MovieCamera;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.StaticScene
{
	// Token: 0x02006ABA RID: 27322
	[NullableContext(1)]
	[Nullable(0)]
	public class BindTargetSetting
	{
		// Token: 0x1700A27D RID: 41597
		// (get) Token: 0x060438D7 RID: 276695 RVA: 0x0116AED8 File Offset: 0x011690D8
		// (set) Token: 0x060438D8 RID: 276696 RVA: 0x0116AEE0 File Offset: 0x011690E0
		public EMovieCameraSequenceSettingBindTargetType BindTargetType { get; set; }

		// Token: 0x1700A27E RID: 41598
		// (get) Token: 0x060438D9 RID: 276697 RVA: 0x0116AEE9 File Offset: 0x011690E9
		// (set) Token: 0x060438DA RID: 276698 RVA: 0x0116AEF1 File Offset: 0x011690F1
		public FName AttachSocketName { get; set; }

		// Token: 0x1700A27F RID: 41599
		// (get) Token: 0x060438DB RID: 276699 RVA: 0x0116AEFA File Offset: 0x011690FA
		// (set) Token: 0x060438DC RID: 276700 RVA: 0x0116AF02 File Offset: 0x01169102
		public Vector AttachLocationOffset { get; set; }

		// Token: 0x1700A280 RID: 41600
		// (get) Token: 0x060438DD RID: 276701 RVA: 0x0116AF0B File Offset: 0x0116910B
		// (set) Token: 0x060438DE RID: 276702 RVA: 0x0116AF13 File Offset: 0x01169113
		public Rotator AttachRotatorOffset { get; set; }

		// Token: 0x1700A281 RID: 41601
		// (get) Token: 0x060438DF RID: 276703 RVA: 0x0116AF1C File Offset: 0x0116911C
		// (set) Token: 0x060438E0 RID: 276704 RVA: 0x0116AF24 File Offset: 0x01169124
		public Vector SpecificLocationOffset { get; set; }

		// Token: 0x1700A282 RID: 41602
		// (get) Token: 0x060438E1 RID: 276705 RVA: 0x0116AF2D File Offset: 0x0116912D
		// (set) Token: 0x060438E2 RID: 276706 RVA: 0x0116AF35 File Offset: 0x01169135
		public Rotator SpecificRotatorOffset { get; set; }

		// Token: 0x1700A283 RID: 41603
		// (get) Token: 0x060438E3 RID: 276707 RVA: 0x0116AF3E File Offset: 0x0116913E
		// (set) Token: 0x060438E4 RID: 276708 RVA: 0x0116AF46 File Offset: 0x01169146
		public Vector WorldLocation { get; set; }

		// Token: 0x1700A284 RID: 41604
		// (get) Token: 0x060438E5 RID: 276709 RVA: 0x0116AF4F File Offset: 0x0116914F
		// (set) Token: 0x060438E6 RID: 276710 RVA: 0x0116AF57 File Offset: 0x01169157
		public Rotator WorldRotation { get; set; }

		// Token: 0x060438E7 RID: 276711 RVA: 0x0116AF60 File Offset: 0x01169160
		public BindTargetSetting(EMovieCameraSequenceSettingBindTargetType bindTargetType, FName attachSocketName, Vector attachLocationOffset, Rotator attachRotatorOffset, Vector specificLocationOffset, Rotator specificRotatorOffset, Vector worldLocation, Rotator worldRotation)
		{
			this.BindTargetType = bindTargetType;
			this.AttachSocketName = attachSocketName;
			this.AttachLocationOffset = attachLocationOffset;
			this.AttachRotatorOffset = attachRotatorOffset;
			this.SpecificLocationOffset = specificLocationOffset;
			this.SpecificRotatorOffset = specificRotatorOffset;
			this.WorldLocation = worldLocation;
			this.WorldRotation = worldRotation;
		}

		// Token: 0x060438E8 RID: 276712 RVA: 0x0116AFB0 File Offset: 0x011691B0
		public bool IsBindToTarget()
		{
			return this.BindTargetType == EMovieCameraSequenceSettingBindTargetType.绑定到目标身上;
		}

		// Token: 0x060438E9 RID: 276713 RVA: 0x0116AFBB File Offset: 0x011691BB
		public bool IsBindToTargetAndPutWorld()
		{
			return this.BindTargetType == EMovieCameraSequenceSettingBindTargetType.根据目标位置放置到世界;
		}

		// Token: 0x060438EA RID: 276714 RVA: 0x0116AFC6 File Offset: 0x011691C6
		public bool IsBindToWorld()
		{
			return this.BindTargetType == EMovieCameraSequenceSettingBindTargetType.放置到世界;
		}
	}
}
