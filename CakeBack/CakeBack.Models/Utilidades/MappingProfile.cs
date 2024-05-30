using CakeBack.Models.Entidades;
using CakeBack.Models.VModels.CategoryDTO;
using CakeBack.Models.VModels.SubCategoryDTO;
using Riok.Mapperly.Abstractions;


namespace CakeBack.Models.Utilidades
{
    [Mapper]
    public partial class MappingProfile
    {
        public partial CategoryDTO MapToCategoryDTO(Category category);
        public partial Category MapToCategory(CategoryCreationDTO categoryCreationDto);

        public partial SubCategoryDTO MapToSubCategoryDTO(SubCategory subCategory);
        public partial SubCategory MapToSubCategory(SubCategoryCreationDTO subCategoryCreationDto);
        public partial void MapToCategory(CategoryCreationDTO categoryCreationDto, Category category);
        public partial void MapToSubCategory(SubCategoryCreationDTO subCategoryCreationDto, SubCategory subCategory);
    }
}
