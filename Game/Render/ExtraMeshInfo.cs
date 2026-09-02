using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Render
{
	// Token: 0x02004748 RID: 18248
	[NullableContext(1)]
	[Nullable(0)]
	public class ExtraMeshInfo
	{
		// Token: 0x0602F5A8 RID: 193960 RVA: 0x00B3B874 File Offset: 0x00B39A74
		public ExtraMeshInfo(USkeletalMeshComponent sourceMeshComp, USkeletalMeshComponent extraMeshComp, string extraMeshName)
		{
			this.SourceComponent = sourceMeshComp;
			this.Component = extraMeshComp;
			this.Name = extraMeshName;
			extraMeshComp.K2_AttachToComponent(sourceMeshComp, null, EAttachmentRule.KeepRelative, EAttachmentRule.KeepRelative, EAttachmentRule.KeepRelative, false, true);
			extraMeshComp.SetSkeletalMesh(sourceMeshComp.SkeletalMesh, true);
			extraMeshComp.SetVisibility(false, false);
			extraMeshComp.SetComponentTickEnabled(false);
			extraMeshComp.SetCollisionEnabled(ECollisionEnabled.NoCollision);
			int numMaterials = this.Component.GetNumMaterials();
			for (int i = 0; i < numMaterials; i++)
			{
				this.Component.SetMaterial(i, Singleton<RenderDataManager>.Instance.GetEmptyMaterial());
			}
		}

		// Token: 0x0602F5A9 RID: 193961 RVA: 0x00B3B90C File Offset: 0x00B39B0C
		public void AddUsage()
		{
			if (this.UsageCount == 0)
			{
				this.Component.SetVisibility(true, false);
				this.Component.SetComponentTickEnabled(true);
				this.Component.SetMasterPoseComponent(this.SourceComponent, false);
			}
			this.UsageCount++;
		}

		// Token: 0x0602F5AA RID: 193962 RVA: 0x00B3B95C File Offset: 0x00B39B5C
		public unsafe void RemoveUsage()
		{
			if (this.UsageCount <= 0)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.RenderCharacter;
				ELogAuthor author = ELogAuthor.LSY;
				string message = "ExtraMeshInfo UsageCount计数错误";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Name", this.Name);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("UsageCount", this.UsageCount);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return;
			}
			this.UsageCount--;
			if (this.UsageCount == 0)
			{
				this.Component.SetVisibility(false, false);
				this.Component.SetComponentTickEnabled(false);
				this.Component.SetMasterPoseComponent(null, false);
			}
		}

		// Token: 0x0401AF6F RID: 110447
		public string Name = string.Empty;

		// Token: 0x0401AF70 RID: 110448
		[Nullable(2)]
		public USkeletalMeshComponent SourceComponent;

		// Token: 0x0401AF71 RID: 110449
		[Nullable(2)]
		public USkeletalMeshComponent Component;

		// Token: 0x0401AF72 RID: 110450
		public int UsageCount;
	}
}
