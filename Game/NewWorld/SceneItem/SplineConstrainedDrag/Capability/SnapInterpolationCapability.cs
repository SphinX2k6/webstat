using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Capability;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.SceneItem.SplineConstrainedDrag.Capability
{
	// Token: 0x02004827 RID: 18471
	public class SnapInterpolationCapability : Capability
	{
		// Token: 0x06030113 RID: 196883 RVA: 0x00BA6A1F File Offset: 0x00BA4C1F
		[NullableContext(2)]
		public SnapInterpolationCapability(ICapabilityGameObject ownerGameObject = null) : base(ownerGameObject)
		{
		}

		// Token: 0x06030114 RID: 196884 RVA: 0x00BA6A28 File Offset: 0x00BA4C28
		[NullableContext(1)]
		protected override ICapabilityConfig GetDefaultConfig()
		{
			return new CapabilityConfig
			{
				Tags = new List<int>(),
				TickGroup = new ETickingGroup?(ETickingGroup.TG_PrePhysics),
				TickGroupOrder = 100,
				InterruptsTags = new List<int>()
			};
		}

		// Token: 0x06030115 RID: 196885 RVA: 0x00BA6A59 File Offset: 0x00BA4C59
		public override void Setup()
		{
		}

		// Token: 0x06030116 RID: 196886 RVA: 0x00BA6A5B File Offset: 0x00BA4C5B
		public override void PreTick(float deltaMilliseconds)
		{
		}

		// Token: 0x06030117 RID: 196887 RVA: 0x00BA6A60 File Offset: 0x00BA4C60
		public override bool ShouldActivate()
		{
			ICapabilityGameObject ownerGameObject = this.OwnerGameObject;
			if (ownerGameObject == null)
			{
				return false;
			}
			SnapInterpolationData capabilityData = ownerGameObject.GetCapabilityData<SnapInterpolationData>(typeof(SnapInterpolationData));
			return ((capabilityData != null) ? new bool?(capabilityData.Active) : null).GetValueOrDefault();
		}

		// Token: 0x06030118 RID: 196888 RVA: 0x00BA6AAC File Offset: 0x00BA4CAC
		public override bool ShouldDeactivate()
		{
			ICapabilityGameObject ownerGameObject = this.OwnerGameObject;
			if (ownerGameObject == null)
			{
				return true;
			}
			SnapInterpolationData capabilityData = ownerGameObject.GetCapabilityData<SnapInterpolationData>(typeof(SnapInterpolationData));
			return !((capabilityData != null) ? new bool?(capabilityData.Active) : null).GetValueOrDefault();
		}

		// Token: 0x06030119 RID: 196889 RVA: 0x00BA6AF8 File Offset: 0x00BA4CF8
		public override void OnActivated()
		{
		}

		// Token: 0x0603011A RID: 196890 RVA: 0x00BA6AFA File Offset: 0x00BA4CFA
		public override void OnDeactivated()
		{
		}

		// Token: 0x0603011B RID: 196891 RVA: 0x00BA6AFC File Offset: 0x00BA4CFC
		public override void TickActive(float deltaMilliseconds)
		{
			ICapabilityGameObject ownerGameObject = this.OwnerGameObject;
			SnapInterpolationData snapInterpolationData = (ownerGameObject != null) ? ownerGameObject.GetCapabilityData<SnapInterpolationData>(typeof(SnapInterpolationData)) : null;
			if (snapInterpolationData == null || !snapInterpolationData.Active || snapInterpolationData.SetDistanceFunc == null)
			{
				return;
			}
			snapInterpolationData.Elapsed += deltaMilliseconds * 0.001f;
			float duration = snapInterpolationData.Duration;
			float num = (duration > 0f) ? Singleton<MathUtils>.Instance.Clamp(snapInterpolationData.Elapsed / duration, 0f, 1f) : 1f;
			float arg = Singleton<MathUtils>.Instance.Lerp(snapInterpolationData.StartDistance, snapInterpolationData.TargetDistance, num);
			snapInterpolationData.SetDistanceFunc(arg, false);
			if (num >= 1f)
			{
				snapInterpolationData.Active = false;
				snapInterpolationData.Elapsed = 0f;
			}
		}
	}
}
