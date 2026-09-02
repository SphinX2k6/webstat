using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialController;
using UnrealEngine;

namespace CSharpScript.Game.Render
{
	// Token: 0x02004757 RID: 18263
	[NullableContext(2)]
	[Nullable(0)]
	public class CharMaterialControlRuntimeDataGroup
	{
		// Token: 0x0602F68B RID: 194187 RVA: 0x00B42238 File Offset: 0x00B40438
		[NullableContext(1)]
		public void Init(CharRenderingComponent charRenderingComponent, PD_CharacterControllerDataGroup_C dataGroup, [Nullable(2)] USkeletalMeshComponent animObject = null)
		{
			this.CharRenderingComponent = charRenderingComponent;
			this.DataGroup = dataGroup;
			this.DataMap = new Dictionary<PD_CharacterControllerData_C, float>();
			this.TempRemoveList = new List<PD_CharacterControllerData_C>();
			this.MaterialHandles = new List<int>();
			this.TempMaterialHandles = new List<int>();
			this.IsDead = false;
			this.AnimObject = animObject;
			this.WholeSpawnTime = 0f;
			this.HaveRuntimeData = false;
			MapUtils.ForEach<PD_CharacterControllerData_C, float>(this.DataGroup.DataMap, delegate(PD_CharacterControllerData_C key, float value)
			{
				if (this.WholeSpawnTime < value)
				{
					this.WholeSpawnTime = value;
				}
				this.HaveRuntimeData = (this.HaveRuntimeData || key.DataType == ECharacterControllerType.Runtime);
				if (value > 0f)
				{
					this.DataMap.Add(key, value);
					return;
				}
				this.MaterialHandles.Add((int)charRenderingComponent.AddMaterialControllerDataWithAnimObject(key, this.AnimObject, null));
			});
		}

		// Token: 0x0602F68C RID: 194188 RVA: 0x00B422D4 File Offset: 0x00B404D4
		public void BeforeUpdateState(float deltaTime, float timeDilation)
		{
			if (!this.IgnoreTimeDilation)
			{
				this.IgnoreTimeDilation = this.DataGroup.IgnoreTimeDilation;
			}
			float num = deltaTime;
			if (!this.IgnoreTimeDilation && ControllerBase<RenderModuleController>.Instance.IsGamePaused)
			{
				return;
			}
			if (!this.IgnoreTimeDilation)
			{
				num = deltaTime * timeDilation;
			}
			this.WholeSpawnTime -= num;
			List<PD_CharacterControllerData_C> list = new List<PD_CharacterControllerData_C>();
			foreach (KeyValuePair<PD_CharacterControllerData_C, float> keyValuePair in this.DataMap)
			{
				PD_CharacterControllerData_C key = keyValuePair.Key;
				float num2 = keyValuePair.Value - num;
				if (num2 <= 0f)
				{
					this.MaterialHandles.Add((int)this.CharRenderingComponent.AddMaterialControllerDataWithAnimObject(key, this.AnimObject, null));
					list.Add(key);
				}
				else
				{
					this.DataMap[key] = num2;
				}
			}
			if (list.Count > 0)
			{
				foreach (PD_CharacterControllerData_C key2 in list)
				{
					this.DataMap.Remove(key2);
				}
			}
			this.TempRemoveList = new List<PD_CharacterControllerData_C>();
		}

		// Token: 0x0602F68D RID: 194189 RVA: 0x00B42420 File Offset: 0x00B40620
		public void AfterUpdateState(float deltaTime)
		{
			if (!this.HaveRuntimeData && this.WholeSpawnTime <= 0f)
			{
				this.TempMaterialHandles = new List<int>();
				for (int i = 0; i < this.MaterialHandles.Count; i++)
				{
					if (this.CharRenderingComponent.IsMaterialControllerDataValid(this.MaterialHandles[i]))
					{
						this.TempMaterialHandles.Add(this.MaterialHandles[i]);
					}
				}
				this.MaterialHandles = this.TempMaterialHandles;
				this.IsDead = (this.MaterialHandles.Count == 0 && this.DataMap.Count == 0);
			}
		}

		// Token: 0x0602F68E RID: 194190 RVA: 0x00B424CC File Offset: 0x00B406CC
		public void EndState()
		{
			this.TempRemoveList = new List<PD_CharacterControllerData_C>();
			this.DataMap.Clear();
			foreach (int handle in this.MaterialHandles)
			{
				this.CharRenderingComponent.RemoveMaterialControllerData(handle);
			}
			this.IsDead = true;
		}

		// Token: 0x0602F68F RID: 194191 RVA: 0x00B42544 File Offset: 0x00B40744
		public void EndStateWithEnding()
		{
			this.TempRemoveList = new List<PD_CharacterControllerData_C>();
			this.DataMap.Clear();
			foreach (int handle in this.MaterialHandles)
			{
				this.CharRenderingComponent.RemoveMaterialControllerDataWithEnding(handle);
			}
			this.IsDead = true;
		}

		// Token: 0x0602F690 RID: 194192 RVA: 0x00B425BC File Offset: 0x00B407BC
		public void SetEffectProgress(float progress)
		{
			foreach (int handleId in this.MaterialHandles)
			{
				this.CharRenderingComponent.SetEffectProgress(progress, handleId);
			}
		}

		// Token: 0x0401AFE3 RID: 110563
		public CharRenderingComponent CharRenderingComponent;

		// Token: 0x0401AFE4 RID: 110564
		public PD_CharacterControllerDataGroup_C DataGroup;

		// Token: 0x0401AFE5 RID: 110565
		public USkeletalMeshComponent AnimObject;

		// Token: 0x0401AFE6 RID: 110566
		public bool IsDead;

		// Token: 0x0401AFE7 RID: 110567
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Dictionary<PD_CharacterControllerData_C, float> DataMap;

		// Token: 0x0401AFE8 RID: 110568
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private List<PD_CharacterControllerData_C> TempRemoveList;

		// Token: 0x0401AFE9 RID: 110569
		private List<int> MaterialHandles;

		// Token: 0x0401AFEA RID: 110570
		private List<int> TempMaterialHandles;

		// Token: 0x0401AFEB RID: 110571
		private float WholeSpawnTime;

		// Token: 0x0401AFEC RID: 110572
		private bool HaveRuntimeData;

		// Token: 0x0401AFED RID: 110573
		private bool IgnoreTimeDilation;
	}
}
