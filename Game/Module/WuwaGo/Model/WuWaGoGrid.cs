using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Component;
using CSharpScript.Game.NewWorld.SceneItem.Common.Component;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.WuwaGo.Model
{
	// Token: 0x02004AD5 RID: 19157
	[NullableContext(1)]
	[Nullable(0)]
	public class WuWaGoGrid : WuWaGoBaseUnit
	{
		// Token: 0x06031F17 RID: 204567 RVA: 0x00C810B8 File Offset: 0x00C7F2B8
		public WuWaGoGrid(Vector coordinate, Rotator rotator, EGridShape gridShape, IWuWaGoGridLinkData gridLinkConfig, [Nullable(2)] IWuWaGoGridLinkData gearLinkConfig = null, [Nullable(2)] Vector attachedCubeCoordinate = null) : base(coordinate, rotator)
		{
		}

		// Token: 0x17008525 RID: 34085
		// (get) Token: 0x06031F18 RID: 204568 RVA: 0x00C81139 File Offset: 0x00C7F339
		public override bool Actionable
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17008526 RID: 34086
		// (get) Token: 0x06031F19 RID: 204569 RVA: 0x00C8113C File Offset: 0x00C7F33C
		public override bool MoveAbility
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17008527 RID: 34087
		// (get) Token: 0x06031F1A RID: 204570 RVA: 0x00C8113F File Offset: 0x00C7F33F
		// (set) Token: 0x06031F1B RID: 204571 RVA: 0x00C81147 File Offset: 0x00C7F347
		[Nullable(2)]
		public AActor Applique { [NullableContext(2)] get; [NullableContext(2)] private set; }

		// Token: 0x06031F1C RID: 204572 RVA: 0x00C81150 File Offset: 0x00C7F350
		[NullableContext(2)]
		protected override AActor GetActorRaw()
		{
			return ControllerBase<CharacterController>.Instance.GetActor(this.EntityHandle);
		}

		// Token: 0x06031F1D RID: 204573 RVA: 0x00C81162 File Offset: 0x00C7F362
		public override IRollbackCapture CaptureRollback()
		{
			return new GridRollbackCapture(this);
		}

		// Token: 0x17008528 RID: 34088
		// (get) Token: 0x06031F1E RID: 204574 RVA: 0x00C8116A File Offset: 0x00C7F36A
		[Nullable(2)]
		public EntityHandle EntityHandle
		{
			[NullableContext(2)]
			get
			{
				return ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(this.EntityPbDataIdValue);
			}
		}

		// Token: 0x17008529 RID: 34089
		// (get) Token: 0x06031F1F RID: 204575 RVA: 0x00C8117C File Offset: 0x00C7F37C
		[Nullable(2)]
		public SceneItemMoveComponent SceneItemMoveComponent
		{
			[NullableContext(2)]
			get
			{
				EntityHandle entityHandle = this.EntityHandle;
				if (entityHandle == null)
				{
					return null;
				}
				WorldEntity entity = entityHandle.Entity;
				if (entity == null)
				{
					return null;
				}
				return entity.GetComponent<SceneItemMoveComponent>();
			}
		}

		// Token: 0x1700852A RID: 34090
		// (get) Token: 0x06031F20 RID: 204576 RVA: 0x00C8119A File Offset: 0x00C7F39A
		public bool IsOccupied
		{
			get
			{
				return this.OccupiedUnit != 0;
			}
		}

		// Token: 0x1700852B RID: 34091
		// (get) Token: 0x06031F21 RID: 204577 RVA: 0x00C811A5 File Offset: 0x00C7F3A5
		public int OccupiedUnitId
		{
			get
			{
				return this.OccupiedUnit;
			}
		}

		// Token: 0x1700852C RID: 34092
		// (get) Token: 0x06031F22 RID: 204578 RVA: 0x00C811AD File Offset: 0x00C7F3AD
		public bool IsEntityGrid
		{
			get
			{
				return this.EntityPbDataIdValue != 0;
			}
		}

		// Token: 0x1700852D RID: 34093
		// (get) Token: 0x06031F23 RID: 204579 RVA: 0x00C811B8 File Offset: 0x00C7F3B8
		public int EntityPbDataId
		{
			get
			{
				return this.EntityPbDataIdValue;
			}
		}

		// Token: 0x1700852E RID: 34094
		// (get) Token: 0x06031F24 RID: 204580 RVA: 0x00C811C0 File Offset: 0x00C7F3C0
		public EWuWaGoEntityType? EntityType
		{
			get
			{
				return this.EntityTypeValue;
			}
		}

		// Token: 0x1700852F RID: 34095
		// (get) Token: 0x06031F25 RID: 204581 RVA: 0x00C811C8 File Offset: 0x00C7F3C8
		public bool HasAttachedGameplayEntity
		{
			get
			{
				return this.AttachedGameplayEntityPbDataIdsValue.Count > 0;
			}
		}

		// Token: 0x17008530 RID: 34096
		// (get) Token: 0x06031F26 RID: 204582 RVA: 0x00C811D8 File Offset: 0x00C7F3D8
		public IReadOnlyList<int> AttachedGameplayEntityPbDataIds
		{
			get
			{
				return this.AttachedGameplayEntityPbDataIdsValue;
			}
		}

		// Token: 0x17008531 RID: 34097
		// (get) Token: 0x06031F27 RID: 204583 RVA: 0x00C811E0 File Offset: 0x00C7F3E0
		public bool IsEndPoint
		{
			get
			{
				return this.EntityTypeValue.GetValueOrDefault() == EWuWaGoEntityType.EndGrid;
			}
		}

		// Token: 0x17008532 RID: 34098
		// (get) Token: 0x06031F28 RID: 204584 RVA: 0x00C811F0 File Offset: 0x00C7F3F0
		public IReadOnlyList<Vector> LinkedDirections
		{
			get
			{
				return this.LinkDirections;
			}
		}

		// Token: 0x17008533 RID: 34099
		// (get) Token: 0x06031F29 RID: 204585 RVA: 0x00C811F8 File Offset: 0x00C7F3F8
		public IReadOnlyList<Vector> GearLinkDirections
		{
			get
			{
				return this.GearLinkDirectionsInternal;
			}
		}

		// Token: 0x17008534 RID: 34100
		// (get) Token: 0x06031F2A RID: 204586 RVA: 0x00C81200 File Offset: 0x00C7F400
		public bool HasGearPath
		{
			get
			{
				return this.HasGearPathInternal;
			}
		}

		// Token: 0x17008535 RID: 34101
		// (get) Token: 0x06031F2B RID: 204587 RVA: 0x00C81208 File Offset: 0x00C7F408
		[Nullable(2)]
		public IWallFrame WallFrame
		{
			[NullableContext(2)]
			get
			{
				return this.WallFrameInfo;
			}
		}

		// Token: 0x06031F2C RID: 204588 RVA: 0x00C81210 File Offset: 0x00C7F410
		public bool IsBidirectionalLinkedTo(WuWaGoGrid other)
		{
			double dx = other.Coordinate.X - base.Coordinate.X;
			double dy = other.Coordinate.Y - base.Coordinate.Y;
			double dz = other.Coordinate.Z - base.Coordinate.Z;
			return this.LinkDirections.Any((Vector d) => d.X.Equals(dx) && d.Y.Equals(dy) && d.Z.Equals(dz)) && other.LinkDirections.Any((Vector d) => d.X.Equals(-dx) && d.Y.Equals(-dy) && d.Z.Equals(-dz));
		}

		// Token: 0x06031F2D RID: 204589 RVA: 0x00C812AC File Offset: 0x00C7F4AC
		public void InitOpeningDirections()
		{
			this.InitRotatedOpeningDirections(this.GridLinkConfig.GridLinkType, this.OpeningDirections);
			IWuWaGoGridLinkData gearLinkConfig = this.GearLinkConfig;
			this.HasGearPathInternal = this.InitBaseOpeningDirections((gearLinkConfig != null) ? new EWuWaGoGridLinkType?(gearLinkConfig.GridLinkType) : null, this.GearOpeningDirections);
		}

		// Token: 0x06031F2E RID: 204590 RVA: 0x00C81304 File Offset: 0x00C7F504
		private void InitRotatedOpeningDirections(EWuWaGoGridLinkType linkType, List<Vector> targetDirections)
		{
			targetDirections.Clear();
			IReadOnlyList<Vector> readOnlyList;
			if (!WuWaGoGrid.BaseOpeningPatterns.TryGetValue(linkType, out readOnlyList) || readOnlyList.Count == 0)
			{
				return;
			}
			Quat quat = this.GetLinkRotator().Quaternion(null);
			foreach (Vector inV in readOnlyList)
			{
				Vector vector = Vector.Create();
				quat.RotateVector(inV, vector);
				vector.Set((double)((float)Math.Round(vector.X)), (double)((float)Math.Round(vector.Y)), (double)((float)Math.Round(vector.Z)));
				targetDirections.Add(vector);
			}
		}

		// Token: 0x06031F2F RID: 204591 RVA: 0x00C813BC File Offset: 0x00C7F5BC
		private bool InitBaseOpeningDirections(EWuWaGoGridLinkType? linkType, List<Vector> targetDirections)
		{
			targetDirections.Clear();
			if (linkType == null)
			{
				return false;
			}
			IReadOnlyList<Vector> readOnlyList;
			if (!WuWaGoGrid.BaseOpeningPatterns.TryGetValue(linkType.Value, out readOnlyList) || readOnlyList.Count == 0)
			{
				return false;
			}
			Quat quat = base.Rotator.Quaternion(null);
			foreach (Vector inV in readOnlyList)
			{
				Vector vector = Vector.Create();
				quat.RotateVector(inV, vector);
				vector.Set((double)((float)Math.Round(vector.X)), (double)((float)Math.Round(vector.Y)), (double)((float)Math.Round(vector.Z)));
				targetDirections.Add(vector);
			}
			return true;
		}

		// Token: 0x06031F30 RID: 204592 RVA: 0x00C81484 File Offset: 0x00C7F684
		[NullableContext(0)]
		public UniTask<bool> Create()
		{
			WuWaGoGrid.<Create>d__62 <Create>d__;
			<Create>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<Create>d__.<>4__this = this;
			<Create>d__.<>1__state = -1;
			<Create>d__.<>t__builder.Start<WuWaGoGrid.<Create>d__62>(ref <Create>d__);
			return <Create>d__.<>t__builder.Task;
		}

		// Token: 0x06031F31 RID: 204593 RVA: 0x00C814C8 File Offset: 0x00C7F6C8
		public void Destroy()
		{
			AActor applique = this.Applique;
			if (applique != null && applique.IsValid())
			{
				WuWaGoFactory.DestroyApplique(this.Applique);
			}
			this.LinkDirections.Clear();
			this.GearLinkDirectionsInternal.Clear();
			this.OccupiedUnitChangedListeners.Clear();
			this.MoveParticipants.Clear();
			this.OccupiedUnit = 0;
			this.OpeningDirections.Clear();
			this.GearOpeningDirections.Clear();
			this.HasGearPathInternal = false;
			this.WallFrameInfo = null;
			AActor applique2 = this.Applique;
			if (applique2 != null && applique2.IsValid())
			{
				WuWaGoFactory.DestroyApplique(this.Applique);
			}
			this.Applique = null;
			this.EntityPbDataIdValue = 0;
			this.EntityTypeValue = null;
			this.AttachedGameplayEntityPbDataIdsValue.Clear();
		}

		// Token: 0x06031F32 RID: 204594 RVA: 0x00C81594 File Offset: 0x00C7F794
		[NullableContext(0)]
		private UniTask<bool> CreateAppliqueActor()
		{
			WuWaGoGrid.<CreateAppliqueActor>d__64 <CreateAppliqueActor>d__;
			<CreateAppliqueActor>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<CreateAppliqueActor>d__.<>4__this = this;
			<CreateAppliqueActor>d__.<>1__state = -1;
			<CreateAppliqueActor>d__.<>t__builder.Start<WuWaGoGrid.<CreateAppliqueActor>d__64>(ref <CreateAppliqueActor>d__);
			return <CreateAppliqueActor>d__.<>t__builder.Task;
		}

		// Token: 0x06031F33 RID: 204595 RVA: 0x00C815D8 File Offset: 0x00C7F7D8
		public unsafe void BuildLinks(WuWaGoModel model)
		{
			this.LinkDirections.Clear();
			this.GearLinkDirectionsInternal.Clear();
			this.WallFrameInfo = null;
			if (this.OpeningDirections.Count == 0 && this.GearOpeningDirections.Count == 0)
			{
				return;
			}
			EGridShape gridShape = this.GridShape;
			if (gridShape != EGridShape.Vertical)
			{
				if (gridShape == EGridShape.Horizontal)
				{
					this.BuildLinksForHorizontal(model, this.OpeningDirections, this.LinkDirections, false);
					this.BuildLinksForHorizontal(model, this.GearOpeningDirections, this.GearLinkDirectionsInternal, true);
					return;
				}
			}
			else
			{
				this.WallFrameInfo = this.GetVerticalGridWallFrame(model, base.Coordinate);
				if (this.WallFrameInfo == null)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.WuWaGo;
					ELogAuthor author = ELogAuthor.YSQ;
					string message = "VerticalGrid 坐标非法或两侧均无归属cube,放弃构建link";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("id", this.Id);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("coordinate", base.Coordinate.ToString());
					instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
					return;
				}
				this.BuildLinksForVertical(model, this.OpeningDirections, this.LinkDirections, false);
				this.BuildLinksForVertical(model, this.GearOpeningDirections, this.GearLinkDirectionsInternal, true);
			}
		}

		// Token: 0x06031F34 RID: 204596 RVA: 0x00C81708 File Offset: 0x00C7F908
		private void BuildLinksForHorizontal(WuWaGoModel model, IReadOnlyList<Vector> openingDirections, List<Vector> targetDirections, bool requireGearPathOnNeighbor = false)
		{
			if (openingDirections.Count == 0)
			{
				return;
			}
			Vector vector = Vector.Create();
			foreach (Vector vector2 in openingDirections)
			{
				base.Coordinate.Addition(vector2, vector);
				WuWaGoGrid grid = model.GetGrid(vector);
				if (grid != null && grid.GridShape == EGridShape.Horizontal)
				{
					if (!requireGearPathOnNeighbor || grid.HasGearPath)
					{
						Vector vector3 = Vector.Create();
						vector3.DeepCopy(vector2);
						targetDirections.Add(vector3);
					}
				}
				else
				{
					Vector vector4 = Vector.Create(vector2.X * 0.5, vector2.Y * 0.5, 0.5);
					base.Coordinate.Addition(vector4, vector);
					WuWaGoGrid grid2 = model.GetGrid(vector);
					if (grid2 != null && grid2.GridShape == EGridShape.Vertical)
					{
						if (!requireGearPathOnNeighbor || grid2.HasGearPath)
						{
							targetDirections.Add(vector4);
						}
					}
					else
					{
						Vector vector5 = Vector.Create(vector2.X * 0.5, vector2.Y * 0.5, -0.5);
						base.Coordinate.Addition(vector5, vector);
						WuWaGoGrid grid3 = model.GetGrid(vector);
						if (grid3 != null && grid3.GridShape == EGridShape.Vertical && (!requireGearPathOnNeighbor || grid3.HasGearPath))
						{
							targetDirections.Add(vector5);
						}
					}
				}
			}
		}

		// Token: 0x06031F35 RID: 204597 RVA: 0x00C81890 File Offset: 0x00C7FA90
		private void BuildLinksForVertical(WuWaGoModel model, IReadOnlyList<Vector> openingDirections, List<Vector> targetDirections, bool requireGearPathOnNeighbor = false)
		{
			if (openingDirections.Count == 0)
			{
				return;
			}
			if (this.WallFrameInfo == null)
			{
				return;
			}
			float ownerOffsetX = this.WallFrameInfo.OwnerOffsetX;
			float ownerOffsetY = this.WallFrameInfo.OwnerOffsetY;
			int wallTangentX = this.WallFrameInfo.WallTangentX;
			int wallTangentY = this.WallFrameInfo.WallTangentY;
			foreach (Vector vector in openingDirections)
			{
				if (vector.Z != 0.0)
				{
					double z = vector.Z;
					if (!this.TryAddNeighborLink(model, (double)ownerOffsetX * z, (double)ownerOffsetY * z, z * 0.5, EGridShape.Horizontal, targetDirections, requireGearPathOnNeighbor))
					{
						this.TryAddNeighborLink(model, 0.0, 0.0, z, EGridShape.Vertical, targetDirections, requireGearPathOnNeighbor);
					}
				}
				else
				{
					double num = vector.X * (double)wallTangentX + vector.Y * (double)wallTangentY;
					if (num != 0.0)
					{
						double num2 = (double)wallTangentX * num;
						double num3 = (double)wallTangentY * num;
						if (!this.TryAddNeighborLink(model, num2 * 0.5 + (double)ownerOffsetX, num3 * 0.5 + (double)ownerOffsetY, 0.0, EGridShape.Vertical, targetDirections, requireGearPathOnNeighbor))
						{
							this.TryAddNeighborLink(model, num2, num3, 0.0, EGridShape.Vertical, targetDirections, requireGearPathOnNeighbor);
						}
					}
				}
			}
		}

		// Token: 0x06031F36 RID: 204598 RVA: 0x00C81A04 File Offset: 0x00C7FC04
		[return: Nullable(2)]
		private IWallFrame GetVerticalGridWallFrame(WuWaGoModel model, Vector coordinate)
		{
			if (this.AttachedCubeCoordinate != null)
			{
				IWallFrame wallFrame = this.BuildWallFrameFromAttachedCube(coordinate, this.AttachedCubeCoordinate);
				if (wallFrame != null)
				{
					return wallFrame;
				}
			}
			if (this.IsEntityGrid)
			{
				IWallFrame wallFrame2 = this.TryGetVerticalGridWallFrameByEntityRotator(coordinate);
				if (wallFrame2 != null)
				{
					return wallFrame2;
				}
			}
			return this.GetVerticalGridWallFrameByGeometry(model, coordinate);
		}

		// Token: 0x06031F37 RID: 204599 RVA: 0x00C81A4C File Offset: 0x00C7FC4C
		[return: Nullable(2)]
		private IWallFrame BuildWallFrameFromAttachedCube(Vector coordinate, Vector cubeCoordinate)
		{
			double num = cubeCoordinate.X - coordinate.X;
			double num2 = cubeCoordinate.Y - coordinate.Y;
			bool flag = Math.Abs(num) <= 9.999999747378752E-05;
			bool flag2 = Math.Abs(num2) <= 9.999999747378752E-05;
			bool flag3 = !flag && flag2;
			bool flag4 = !flag2 && flag;
			if (flag3 == flag4)
			{
				return null;
			}
			int num3 = ((flag3 ? num : num2) > 0.0) ? 1 : -1;
			int num4 = (flag3 > false) ? 1 : 0;
			int num5 = (!flag3) ? 1 : 0;
			int wallTangentX = (!flag3) ? 1 : 0;
			int wallTangentY = (flag3 > false) ? 1 : 0;
			float ownerOffsetX = (float)num4 * 0.5f * (float)num3;
			float ownerOffsetY = (float)num5 * 0.5f * (float)num3;
			return new WallFrame
			{
				WallNormalX = num4,
				WallNormalY = num5,
				WallTangentX = wallTangentX,
				WallTangentY = wallTangentY,
				OwnerSign = num3,
				OwnerOffsetX = ownerOffsetX,
				OwnerOffsetY = ownerOffsetY
			};
		}

		// Token: 0x06031F38 RID: 204600 RVA: 0x00C81B48 File Offset: 0x00C7FD48
		[return: Nullable(2)]
		private IWallFrame TryGetVerticalGridWallFrameByEntityRotator(Vector coordinate)
		{
			double num = coordinate.X - Math.Floor(coordinate.X);
			double num2 = coordinate.Y - Math.Floor(coordinate.Y);
			bool flag = num.Equals(0.5);
			bool flag2 = num2.Equals(0.5);
			if (flag == flag2)
			{
				return null;
			}
			Vector vector = Vector.Create();
			base.Rotator.Quaternion(null).GetAxisZ(vector);
			double num3 = flag ? vector.X : vector.Y;
			int num4 = (num3 > 0.0) ? -1 : ((num3 < 0.0) ? 1 : 0);
			if (num4 == 0)
			{
				return null;
			}
			int num5 = (flag > false) ? 1 : 0;
			int num6 = (!flag) ? 1 : 0;
			int wallTangentX = (!flag) ? 1 : 0;
			int wallTangentY = (flag > false) ? 1 : 0;
			float ownerOffsetX = (float)num5 * 0.5f * (float)num4;
			float ownerOffsetY = (float)num6 * 0.5f * (float)num4;
			return new WallFrame
			{
				WallNormalX = num5,
				WallNormalY = num6,
				WallTangentX = wallTangentX,
				WallTangentY = wallTangentY,
				OwnerSign = num4,
				OwnerOffsetX = ownerOffsetX,
				OwnerOffsetY = ownerOffsetY
			};
		}

		// Token: 0x06031F39 RID: 204601 RVA: 0x00C81C6C File Offset: 0x00C7FE6C
		[return: Nullable(2)]
		private IWallFrame GetVerticalGridWallFrameByGeometry(WuWaGoModel model, Vector coordinate)
		{
			double num = coordinate.X - Math.Floor(coordinate.X);
			double num2 = coordinate.Y - Math.Floor(coordinate.Y);
			bool flag = num.Equals(0.5);
			bool flag2 = num2.Equals(0.5);
			if (flag == flag2)
			{
				return null;
			}
			int num3 = (flag > false) ? 1 : 0;
			int num4 = (!flag) ? 1 : 0;
			int wallTangentX = (!flag) ? 1 : 0;
			int wallTangentY = (flag > false) ? 1 : 0;
			for (int i = 0; i < 16; i++)
			{
				double inZ = coordinate.Z + 0.5 + (double)i;
				foreach (int num5 in new int[]
				{
					1,
					-1
				})
				{
					double inX = coordinate.X + (double)((float)num3 * 0.5f * (float)num5);
					double inY = coordinate.Y + (double)((float)num4 * 0.5f * (float)num5);
					WuWaGoGrid.ProbeBufferTemp.Set(inX, inY, inZ);
					WuWaGoGrid grid = model.GetGrid(WuWaGoGrid.ProbeBufferTemp);
					if (grid != null && grid.GridShape == EGridShape.Horizontal)
					{
						return new WallFrame
						{
							WallNormalX = num3,
							WallNormalY = num4,
							WallTangentX = wallTangentX,
							WallTangentY = wallTangentY,
							OwnerSign = num5,
							OwnerOffsetX = (float)num3 * 0.5f * (float)num5,
							OwnerOffsetY = (float)num4 * 0.5f * (float)num5
						};
					}
				}
			}
			return null;
		}

		// Token: 0x06031F3A RID: 204602 RVA: 0x00C81DEC File Offset: 0x00C7FFEC
		private bool TryAddNeighborLink(WuWaGoModel model, double dx, double dy, double dz, EGridShape expectedShape, List<Vector> targetDirections, bool requireGearPathOnNeighbor = false)
		{
			WuWaGoGrid.ProbeBufferTemp.Set(base.Coordinate.X + dx, base.Coordinate.Y + dy, base.Coordinate.Z + dz);
			WuWaGoGrid grid = model.GetGrid(WuWaGoGrid.ProbeBufferTemp);
			if (grid == null || grid.GridShape != expectedShape)
			{
				return false;
			}
			if (!requireGearPathOnNeighbor || grid.HasGearPath)
			{
				targetDirections.Add(Vector.Create(dx, dy, dz));
			}
			return true;
		}

		// Token: 0x06031F3B RID: 204603 RVA: 0x00C81E64 File Offset: 0x00C80064
		public Rotator GetLinkRotator()
		{
			float yaw = WuWaGoGrid.RotationTypeToAngle[this.GridLinkConfig.RotationType];
			Rotator rotator = Rotator.Create(0f, yaw, 0f);
			Quat quat = base.Rotator.Quaternion(null);
			Quat inQ = rotator.Quaternion(null);
			Quat quat2 = Quat.Create(0f, 0f, 0f, 1f);
			quat.Multiply(inQ, quat2);
			return quat2.Rotator(null);
		}

		// Token: 0x06031F3C RID: 204604 RVA: 0x00C81ED4 File Offset: 0x00C800D4
		public void AddOccupiedUnitChangedListener(WuWaGoGridOccupiedUnitChangedListener listener)
		{
			this.OccupiedUnitChangedListeners.Add(listener);
		}

		// Token: 0x06031F3D RID: 204605 RVA: 0x00C81EE3 File Offset: 0x00C800E3
		public void RemoveOccupiedUnitChangedListener(WuWaGoGridOccupiedUnitChangedListener listener)
		{
			this.OccupiedUnitChangedListeners.Remove(listener);
		}

		// Token: 0x06031F3E RID: 204606 RVA: 0x00C81EF4 File Offset: 0x00C800F4
		public void SetOccupiedUnit(int? unitId = null)
		{
			int valueOrDefault = unitId.GetValueOrDefault();
			if (this.OccupiedUnit == valueOrDefault)
			{
				return;
			}
			int occupiedUnit = this.OccupiedUnit;
			this.OccupiedUnit = valueOrDefault;
			if (WuWaGoRollbackPreStates.IsSuppressed())
			{
				return;
			}
			foreach (WuWaGoGridOccupiedUnitChangedListener wuWaGoGridOccupiedUnitChangedListener in this.OccupiedUnitChangedListeners)
			{
				wuWaGoGridOccupiedUnitChangedListener(this, occupiedUnit, valueOrDefault);
			}
		}

		// Token: 0x06031F3F RID: 204607 RVA: 0x00C81F70 File Offset: 0x00C80170
		public void RegisterMoveParticipant(IWuWaGoGridMoveParticipant participant)
		{
			this.MoveParticipants.Add(participant);
		}

		// Token: 0x06031F40 RID: 204608 RVA: 0x00C81F7F File Offset: 0x00C8017F
		public void UnregisterMoveParticipant(IWuWaGoGridMoveParticipant participant)
		{
			this.MoveParticipants.Remove(participant);
		}

		// Token: 0x06031F41 RID: 204609 RVA: 0x00C81F8E File Offset: 0x00C8018E
		public IReadOnlyList<IWuWaGoGridMoveParticipant> SnapshotMoveParticipants()
		{
			return new List<IWuWaGoGridMoveParticipant>(this.MoveParticipants);
		}

		// Token: 0x06031F42 RID: 204610 RVA: 0x00C81F9B File Offset: 0x00C8019B
		public void SetEntity(int pbDataId, EWuWaGoEntityType type)
		{
			this.EntityPbDataIdValue = pbDataId;
			this.EntityTypeValue = new EWuWaGoEntityType?(type);
		}

		// Token: 0x06031F43 RID: 204611 RVA: 0x00C81FB0 File Offset: 0x00C801B0
		public void AttachGameplayEntity(int pbDataId)
		{
			if (this.AttachedGameplayEntityPbDataIdsValue.Contains(pbDataId))
			{
				return;
			}
			this.AttachedGameplayEntityPbDataIdsValue.Add(pbDataId);
		}

		// Token: 0x0401D3A3 RID: 119715
		private readonly List<Vector> OpeningDirections = new List<Vector>();

		// Token: 0x0401D3A4 RID: 119716
		private readonly List<Vector> GearOpeningDirections = new List<Vector>();

		// Token: 0x0401D3A5 RID: 119717
		private readonly List<Vector> LinkDirections = new List<Vector>();

		// Token: 0x0401D3A6 RID: 119718
		private readonly List<Vector> GearLinkDirectionsInternal = new List<Vector>();

		// Token: 0x0401D3A7 RID: 119719
		private bool HasGearPathInternal;

		// Token: 0x0401D3A8 RID: 119720
		[Nullable(2)]
		private IWallFrame WallFrameInfo;

		// Token: 0x0401D3A9 RID: 119721
		[StaticVariableRuleIgnore]
		private static readonly Vector ProbeBufferTemp = Vector.Create();

		// Token: 0x0401D3AA RID: 119722
		private const int MAX_CUBE_STACK_PROBE = 16;

		// Token: 0x0401D3AB RID: 119723
		private const float GRID_COORDINATE_EPSILON = 0.0001f;

		// Token: 0x0401D3AC RID: 119724
		private int OccupiedUnit;

		// Token: 0x0401D3AD RID: 119725
		private readonly HashSet<WuWaGoGridOccupiedUnitChangedListener> OccupiedUnitChangedListeners = new HashSet<WuWaGoGridOccupiedUnitChangedListener>();

		// Token: 0x0401D3AE RID: 119726
		private readonly HashSet<IWuWaGoGridMoveParticipant> MoveParticipants = new HashSet<IWuWaGoGridMoveParticipant>();

		// Token: 0x0401D3AF RID: 119727
		private int EntityPbDataIdValue;

		// Token: 0x0401D3B0 RID: 119728
		private EWuWaGoEntityType? EntityTypeValue;

		// Token: 0x0401D3B1 RID: 119729
		private readonly List<int> AttachedGameplayEntityPbDataIdsValue = new List<int>();

		// Token: 0x0401D3B3 RID: 119731
		public EGridShape GridShape = gridShape;

		// Token: 0x0401D3B4 RID: 119732
		public IWuWaGoGridLinkData GridLinkConfig = gridLinkConfig;

		// Token: 0x0401D3B5 RID: 119733
		[Nullable(2)]
		public IWuWaGoGridLinkData GearLinkConfig = gearLinkConfig;

		// Token: 0x0401D3B6 RID: 119734
		[Nullable(2)]
		public Vector AttachedCubeCoordinate = attachedCubeCoordinate;

		// Token: 0x0401D3B7 RID: 119735
		[StaticVariableRuleIgnore]
		private static readonly Dictionary<EWuWaGoGridRotationType, float> RotationTypeToAngle = new Dictionary<EWuWaGoGridRotationType, float>
		{
			{
				EWuWaGoGridRotationType.Front,
				0f
			},
			{
				EWuWaGoGridRotationType.Right,
				90f
			},
			{
				EWuWaGoGridRotationType.Behind,
				180f
			},
			{
				EWuWaGoGridRotationType.Left,
				270f
			}
		};

		// Token: 0x0401D3B8 RID: 119736
		[StaticVariableRuleIgnore]
		private static readonly Dictionary<EWuWaGoGridLinkType, IReadOnlyList<Vector>> BaseOpeningPatterns = new Dictionary<EWuWaGoGridLinkType, IReadOnlyList<Vector>>
		{
			{
				EWuWaGoGridLinkType.EmptyGrid,
				new List<Vector>()
			},
			{
				EWuWaGoGridLinkType.SingleLinkGrid,
				new List<Vector>
				{
					Vector.ForwardVectorProxy
				}
			},
			{
				EWuWaGoGridLinkType.RightAngleLinkGrid,
				new List<Vector>
				{
					Vector.ForwardVectorProxy,
					Vector.RightVectorProxy
				}
			},
			{
				EWuWaGoGridLinkType.StraightLinkGrid,
				new List<Vector>
				{
					Vector.ForwardVectorProxy,
					Vector.BackwardVectorProxy
				}
			},
			{
				EWuWaGoGridLinkType.ThreeLinkGrid,
				new List<Vector>
				{
					Vector.ForwardVectorProxy,
					Vector.RightVectorProxy,
					Vector.BackwardVectorProxy
				}
			},
			{
				EWuWaGoGridLinkType.AllLinkGrid,
				new List<Vector>
				{
					Vector.ForwardVectorProxy,
					Vector.RightVectorProxy,
					Vector.BackwardVectorProxy,
					Vector.LeftVectorProxy
				}
			}
		};
	}
}
