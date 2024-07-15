using Specifications.Models;

namespace Specifications.Persistence;

public class DigitalContentRepository(ApplicationDbContext dbContext)
    : SpecRepository<DigitalContentItem, ApplicationDbContext>(dbContext), IDigitalContentRepository;
