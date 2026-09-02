using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.SunSpirit.SunSpiritPerform
{
	// Token: 0x02006AB3 RID: 27315
	[NullableContext(1)]
	[Nullable(0)]
	public class SunSpiritNonePerform : SunSpiritBasePerform, ISunSpiritScenePerform
	{
		// Token: 0x0604389B RID: 276635 RVA: 0x01169AFE File Offset: 0x01167CFE
		public SunSpiritNonePerform(SunSpiritData sunSpiritData, Transform initTransform) : base(sunSpiritData)
		{
			this.SavedTransform.Set(initTransform.GetLocation(), initTransform.GetRotation(), initTransform.GetScale3D());
		}

		// Token: 0x0604389C RID: 276636 RVA: 0x01169B30 File Offset: 0x01167D30
		[NullableContext(2)]
		public bool GetTransformData(Vector outLocation = null, object outRotation = null, Vector outScale = null)
		{
			if (outLocation != null)
			{
				outLocation.DeepCopy(this.SavedTransform.GetLocation());
			}
			Quat quat = outRotation as Quat;
			if (quat != null)
			{
				quat.DeepCopy(this.SavedTransform.GetRotation());
			}
			else
			{
				Rotator rotator = outRotation as Rotator;
				if (rotator != null)
				{
					this.SavedTransform.GetRotation().Rotator(rotator);
				}
			}
			if (outScale != null)
			{
				outScale.DeepCopy(this.SavedTransform.GetScale3D());
			}
			return true;
		}

		// Token: 0x0604389D RID: 276637 RVA: 0x01169B9F File Offset: 0x01167D9F
		public bool GetTransform(Transform outTransform)
		{
			outTransform.Set(this.SavedTransform.GetLocation(), this.SavedTransform.GetRotation(), this.SavedTransform.GetScale3D());
			return true;
		}

		// Token: 0x0604389E RID: 276638 RVA: 0x01169BCC File Offset: 0x01167DCC
		[NullableContext(2)]
		public bool SetTransformData(Vector inLocation = null, object inRotation = null, Vector inScale = null)
		{
			if (inLocation != null)
			{
				this.SavedTransform.SetLocation(inLocation);
			}
			Quat quat = inRotation as Quat;
			if (quat != null)
			{
				this.SavedTransform.SetRotation(quat);
			}
			else
			{
				Rotator rotator = inRotation as Rotator;
				if (rotator != null)
				{
					this.SavedTransform.SetRotation(rotator.Quaternion(null));
				}
			}
			if (inScale != null)
			{
				this.SavedTransform.SetScale3D(inScale);
			}
			return true;
		}

		// Token: 0x0604389F RID: 276639 RVA: 0x01169C2C File Offset: 0x01167E2C
		public bool SetTransform(Transform inTransform)
		{
			this.SavedTransform.Set(inTransform.GetLocation(), inTransform.GetRotation(), inTransform.GetScale3D());
			return true;
		}

		// Token: 0x04025BB3 RID: 154547
		private readonly Transform SavedTransform = Transform.Create();
	}
}
